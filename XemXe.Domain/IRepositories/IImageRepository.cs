using XemXe.Domain.Entities;

namespace XemXe.Domain.Repositories;

public interface IImageRepository : IGenericRepository<Image>
{
    Task<List<Image>> GetByCarIdAsync(int carId);
}