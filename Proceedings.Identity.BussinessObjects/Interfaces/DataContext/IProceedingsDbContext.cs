namespace Proceedings.Identity.BussinessObjects.Interfaces.DataContext
{
    public interface IProceedingsDbContext<T> : IUnitOfWork<T>
    {
        //DbSet<Cliente> Clientes { get; }
        //DbSet<Expediente> Expedientes { get; }
        //DbSet<Departamento> Departamentos { get; }
        //DbSet<Tarea> Tareas { get; }
        //DbSet<TipoTarea> TiposTareas { get; }

        //******************************************************************************************
        //ESTÁ TODO EN UnitOfWork
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        //T GetCurrentTransaction();
        //Task<T> BeginTransactionAsync();
        //Task CommitAsync(T transaction);

        //DbSet<TodoList> TodoLists { get; }
        //DbSet<TodoItem> TodoItems { get; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
