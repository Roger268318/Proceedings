namespace Proceedings.EFCore.Repositories.Repositories.Identity
{
    public class RepositoryUserAccess : IRepositoryUserAccess
    {
        private readonly ProceedingsDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        IPasswordHasher<ApplicationUser> _passwordHasher;
        //private readonly IMapper _mapper;
        private readonly IJwtGenerador _jwtGenerador;
        private readonly IUserSesion _usuarioSesion;

        //private readonly ILogger<UserAnonymousRepository> _logger;

        public RepositoryUserAccess(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                       ProceedingsDbContext db,
                       IConfiguration configuration, IJwtGenerador jwtGenerador,
                       IUserSesion usuarioSesion, ILogger<RepositoryUserAccess> logger, IPasswordHasher<ApplicationUser> passwordHasher)

        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _db = db;
            //_mapper = mapper;
            _jwtGenerador = jwtGenerador;
            _usuarioSesion = usuarioSesion;
            //_logger = logger;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserLoginDto> Login(UserLoginDto usuarioLoginDto)
        {
            //var usuarioLoginDto = _mapper.Map<UserLoginDto>(entity);
            //throw new ManejadorExceptions(HttpStatusCode.Unauthorized);
            //throw new Exception("Excepción controlada.");

            var usuario = await _userManager.FindByNameAsync(usuarioLoginDto.UserName);
            if (usuario == null)
            {
                throw new SomeException("An error occurred...");
            }

            var lstRoles = await _userManager.GetRolesAsync(usuario);

            //var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, usuarioLoginDto.Password.Trim(), false);
            var resultado = await _userManager.CheckPasswordAsync(usuario, usuarioLoginDto.Password.Trim());

            if (resultado)
            {
                UserLoginDto usuarioReturn = new UserLoginDto();

                usuarioReturn.Token = _jwtGenerador.CrearToken(usuario, (List<string>)lstRoles);
                usuarioReturn.UserName = usuario.UserName;
                usuarioReturn.Email = usuario.Email;
                usuarioReturn.UserAccess = usuario.UserAccess;

                usuarioReturn.Roles = (List<string>)lstRoles;

                //var _entity = _mapper.Map<T>(usuarioReturn);

                return usuarioReturn;
            }
            else
            {
                throw new SomeException("Error en Login...");
            }
        }

        public async Task<UserRegisterDto> Register(UserRegisterDto usuarioRegisterDto)
        {
            //var usuarioRegisterDto = _mapper.Map<UserRegisterDto>(entity);

            var usuarioExiste = await _userManager.FindByEmailAsync(usuarioRegisterDto.Email);
            if (usuarioExiste != null)
            {
                throw new SomeException("El usuario ya está registrado con este email.");
            }

            var usuario = new ApplicationUser
            {
                Email = usuarioRegisterDto.Email,
                UserName = usuarioRegisterDto.Email,
                UserAccess = usuarioRegisterDto.UserCreate,
                FechaAlta = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))
            };

            var result = await _userManager.CreateAsync(usuario, usuarioRegisterDto.Password);

            if (result.Succeeded)
            {
                var guestUser = _userManager.FindByNameAsync(usuario.UserName).Result;
                var userRole = _userManager.AddToRolesAsync(guestUser, new string[] { "Guest" }).Result;

                var lstRoles = await _userManager.GetRolesAsync(guestUser);

                return new UserRegisterDto
                {
                    Token = _jwtGenerador.CrearToken(usuario, (List<string>)lstRoles),
                    UserName = usuario.UserName,
                    UserCreate = usuario.UserAccess,
                    Email = usuario.Email
                };
                //var _entity = _mapper.Map<T>(usuarioRegisterDto);
            }
            else
            {
                throw new SomeException("No se pudo registrar al nuevo usuario.");
            }
        }


    }
}
