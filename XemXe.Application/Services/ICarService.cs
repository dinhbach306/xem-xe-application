using XemXe.Application.DTOs.Requests;
using XemXe.Application.DTOs.Responses;

namespace XemXe.Application.Services;

public interface ICarService
{
    Task<ApiResponse<List<CarResponse>>> GetAllCarsAsync();
    Task<ApiResponse<CarResponse>> GetCarByIdAsync(int id);
    Task<ApiResponse<List<CarResponse>>> GetCarsByManufacturerAsync(int manufacturerId);
    Task<ApiResponse<CarResponse>> AddCarAsync(CreatedCarRequest request);
}