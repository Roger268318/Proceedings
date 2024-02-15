namespace Proceedings.Entities.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
    {
        bool HasActiveTransaction { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        //Intercambiamos IDbContextTransaction por T
        //IDbContextTransaction GetCurrentTransaction();
        T GetCurrentTransaction();

        Task<T> BeginTransactionAsync();
        Task CommitAsync(T transaction);

    }
}
