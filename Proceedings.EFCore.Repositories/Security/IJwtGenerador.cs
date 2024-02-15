namespace Proceedings.EFCore.Repositories.Security
{
    public interface IJwtGenerador
    {
        string CrearToken(ApplicationUser usuario, List<string> lstRoles);
    }
}
