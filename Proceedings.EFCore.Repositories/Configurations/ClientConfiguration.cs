namespace Proceedings.EFCore.Repositories.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.ClienteId);
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
            builder.Property(t => t.Nacionalidad)
                .HasMaxLength(200);
            builder.Property(t => t.Pais)
                .HasMaxLength(200);
            builder.Property(t => t.Telefono)
                .HasMaxLength(12);
            builder.Property(t => t.Movil)
                .HasMaxLength(12);
            builder.Property(t => t.Email)
                .HasMaxLength(100);
            builder.Property(t => t.UserAccess)
                .HasMaxLength(20)
                .IsRequired();




        }
    }
}
