namespace Proceedings.EFCore.Repositories.Security
{
    public class UserSesion : IUserSesion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserSesion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string ObtenerUsuarioSesion()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
