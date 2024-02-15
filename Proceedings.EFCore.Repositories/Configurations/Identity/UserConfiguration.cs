namespace Proceedings.EFCore.Repositories.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.UserAccess)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.DNI)
                .HasMaxLength(9);
            builder.Property(t => t.Nombre)
                .HasMaxLength(100);
            builder.Property(t => t.Apellidos)
                .HasMaxLength(200);
            builder.Property(t => t.Domicilio)
                .HasMaxLength(200);
            builder.Property(t => t.CP)
                .HasMaxLength(5);
            builder.Property(t => t.Poblacion)
                .HasMaxLength(200);
            builder.Property(t => t.Provincia)
                .HasMaxLength(200);
            builder.Property(t => t.Pais)
                .HasMaxLength(200);
            builder.Property(t => t.Movil)
                .HasMaxLength(12);


        }
    }
}