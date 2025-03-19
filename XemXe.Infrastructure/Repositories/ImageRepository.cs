using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using XemXe.Domain.Entities;
using XemXe.Domain.Repositories;
using XemXe.Infrastructure.Data;

namespace XemXe.Infrastructure.Repositories;

public class ImageRepository :  GenericRepository<Image>, IImageRepository
{
    public ImageRepository(CarDbContext context) : base(context)
    {
    }
    
    public Task<List<Image>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Image>> FindAsync(Expression<Func<Image, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Add(Image entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Image entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Image entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Image>> GetByCarIdAsync(int carId)
    {
        return await _context.Images
            .Where(i => i.CarId == carId)
            .ToListAsync();
    }
}