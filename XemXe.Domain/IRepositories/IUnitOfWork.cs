namespace XemXe.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICarRepository Cars { get; }
    Task<int> CommitAsync();
}