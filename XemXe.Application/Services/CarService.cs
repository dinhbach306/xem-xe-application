using Mapster;
using XemXe.Application.DTOs.Requests;
using XemXe.Application.DTOs.Responses;
using XemXe.Domain.Entities;
using XemXe.Domain.Repositories;

namespace XemXe.Application.Services;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAwsS3Service _s3Service;
    
    public CarService(IUnitOfWork unitOfWork, IAwsS3Service s3Service)
    {
        _unitOfWork = unitOfWork;
        _s3Service = s3Service;
    }
    
    public async Task<ApiResponse<List<CarResponse>>> GetAllCarsAsync()
    {
        try
        {
            var cars = await _unitOfWork.Cars.GetAllAsync();
            var response = cars.Adapt<List<CarResponse>>();
            return ApiResponse<List<CarResponse>>.Success(response, "Lấy tất cả xe thành công");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CarResponse>>.Failure(ex.Message, "Lấy danh sách xe thất bại", 500);
        }
    }

    public async Task<ApiResponse<CarResponse>> GetCarByIdAsync(int id)
    {
        try
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null)
            {
                return ApiResponse<CarResponse>.Failure("Xe không tồn tại", "Lấy xe thất bại", 404);
            }
            var response = car.Adapt<CarResponse>();
            return ApiResponse<CarResponse>.Success(response, "Lấy xe thành công");
        }
        catch (Exception ex)
        {
            return ApiResponse<CarResponse>.Failure(ex.Message, "Lấy xe thất bại", 500);
        }
    }

    public async Task<ApiResponse<List<CarResponse>>> GetCarsByManufacturerAsync(int manufacturerId)
    {
        try
        {
            var cars = await _unitOfWork.Cars.GetByManufacturerAsync(manufacturerId);
            var response = cars.Adapt<List<CarResponse>>();
            return ApiResponse<List<CarResponse>>.Success(response, "Lấy xe theo hãng thành công");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<CarResponse>>.Failure(ex.Message, "Lấy danh sách xe thất bại", 500);
        }
    }

    public async Task<ApiResponse<CarResponse>> AddCarAsync(CreatedCarRequest request)
    {
        try
        {
            var car = request.Adapt<Car>();
            _unitOfWork.Cars.Add(car);
            await _unitOfWork.CommitAsync();
            if (request.Images != null && request.Images.Any())
            {
                var folder = "cars";
                var imageUrls = await _s3Service.UploadFilesAsync(request.Images, folder);
                foreach (var url in imageUrls)
                {
                    var image = new Image { CarId = car.Id, Url = url };
                    _unitOfWork.Images.Add(image);
                }
                await _unitOfWork.CommitAsync();
            }
            
            var response = car.Adapt<CarResponse>();
            return ApiResponse<CarResponse>.Success(response, "Thêm xe thành công", 201);
        } catch (Exception ex)
        {
            return ApiResponse<CarResponse>.Failure(ex.Message, "Thêm xe thất bại", 500);
        }
    }
}