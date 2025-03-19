using XemXe.Domain.Entities;

namespace XemXe.Domain.Repositories;

public interface ICarRepository : IGenericRepository<Car>
{
    Task<List<Car>> GetByManufacturerAsync(int manufacturerId);
}