using XemXe.Domain.Repositories;
using XemXe.Infrastructure.Data;

namespace XemXe.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CarDbContext _context;
    private ICarRepository _carRepository;
    
    public UnitOfWork(CarDbContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }


    public ICarRepository Cars { get { return _carRepository ??= new CarRepository(_context); } }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}