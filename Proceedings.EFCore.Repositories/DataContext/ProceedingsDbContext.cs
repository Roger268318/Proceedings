namespace Proceedings.EFCore.Repositories.DataContext
{
    public class ProceedingsDbContext : IdentityDbContext<ApplicationUser>, IProceedingsDbContext<IDbContextTransaction>
    {
        public ProceedingsDbContext(DbContextOptions<ProceedingsDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Expediente> Expedientes => Set<Expediente>();
        public DbSet<Departamento> Departamentos => Set<Departamento>();
        //public DbSet<Tarea> Tareas => Set<Tarea>();
        //public DbSet<TipoTarea> TiposTareas => Set<TipoTarea>();

        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }

        //public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Expediente> Expediente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //builder.HasDefaultSchema("Identity");
            //builder.Entity<IdentityUser>(entity =>
            //{
            //    entity.ToTable(name: "User");
            //});
            //builder.Entity<IdentityRole>(entity =>
            //{
            //    entity.ToTable(name: "Role");
            //});
            //builder.Entity<IdentityUserRole<string>>(entity =>
            //{
            //    entity.ToTable("UserRoles");
            //});
            //builder.Entity<IdentityUserClaim<string>>(entity =>
            //{
            //    entity.ToTable("UserClaims");
            //});
            //builder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.ToTable("UserLogins");
            //});
            //builder.Entity<IdentityRoleClaim<string>>(entity =>
            //{
            //    entity.ToTable("RoleClaims");
            //});
            //builder.Entity<IdentityUserToken<string>>(entity =>
            //{
            //    entity.ToTable("UserTokens");
            //});

            builder.Entity<RoleMenuPermission>()
                .HasKey(c => new { c.RoleId, c.NavigationMenuId });


            //builder.Entity<Cliente>().HasKey(k => new { k.ClienteId });
            //builder.Entity<Expediente>().HasKey(k => new { k.ExpedienteID });

            //builder.Entity<Expediente>()
            //        .HasOne<Cliente>(s => s.Cliente)
            //        .WithMany(g => g.Expedientes);

            //builder
            //    .Entity<ApplicationUser>()
            //    .HasMany(p => p.Tareas)
            //    .WithMany(p => p.UsersApps)
            //    .UsingEntity(j => j.ToTable("TareasUsers"));


            base.OnModelCreating(builder);
        }

        //Operaciones con Transaciones

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null!;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        public async Task CommitAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        private void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }
    }
}
