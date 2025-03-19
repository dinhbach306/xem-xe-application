using Microsoft.EntityFrameworkCore;
using XemXe.Domain.Entities;
using XemXe.Domain.Repositories;
using XemXe.Infrastructure.Data;

namespace XemXe.Infrastructure.Repositories;

public class CarRepository : GenericRepository<Car>, ICarRepository
{
    public CarRepository(CarDbContext context) : base(context)
    {
    }

    public async Task<List<Car>> GetByManufacturerAsync(int manufacturerId)
    {
        return await _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.Manufacturer)
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.CarType)
            .Include(c => c.Color)
            .Where(c => c.CarModel.ManufacturerId == manufacturerId)
            .ToListAsync();
    }

    public override async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.Manufacturer)
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.CarType)
            .Include(c => c.Color)
            .ToListAsync();
    }
    
    public override async Task<Car?> GetByIdAsync(int id)
    {
        return await _context.Cars
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.Manufacturer)
            .Include(c => c.CarModel)
            .ThenInclude(cm => cm.CarType)
            .Include(c => c.Color)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}