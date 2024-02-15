namespace Proceedings.EFCore.Repositories.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public string? UserAccess { get; set; }
        public string? DNI { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Domicilio { get; set; }
        public string? CP { get; set; }
        public string? Poblacion { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Movil { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaUltimaConexion { get; set; }
        public byte[]? ProfilePicture { get; set; }

        //***************************************************************************
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
