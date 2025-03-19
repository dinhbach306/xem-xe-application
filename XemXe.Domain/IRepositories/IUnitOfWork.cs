namespace XemXe.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICarRepository Cars { get; }
    IImageRepository Images { get; }
    Task<int> CommitAsync();
}