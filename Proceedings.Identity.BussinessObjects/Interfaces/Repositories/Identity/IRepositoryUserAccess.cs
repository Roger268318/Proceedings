namespace Proceedings.Identity.BussinessObjects.Interfaces.Repositories.Identity
{
    public interface IRepositoryUserAccess
    {
        public Task<UserLoginDto> Login(UserLoginDto userlogindto);

        public Task<UserRegisterDto> Register(UserRegisterDto usuario);

        //public Task<UserActualizarDto> ActualizarUsuario(UserActualizarDto usuarioActualizarDto);
        //public Task<UserActualDto> ObtenerUsuarioActual();


    }
}
