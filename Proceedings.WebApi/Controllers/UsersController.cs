using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proceedings.Identity.BussinessObjects.Dtos.Identity;
using Proceedings.Identity.BussinessObjects.Interfaces.Repositories.Identity;

namespace Proceedings.WebApi.Controllers
{
    //https://localhost:7002/api/Usuarios
    [AllowAnonymous]
    [ApiController]
    [Route("api/Usuarios")]
    public class UsersController : ControllerBase
    {

        private readonly IRepositoryUserAccess _usuarioRepository;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryUserAccess usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// LOGIN
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        //[AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserLoginDto>> Login([FromBody] UserLoginDto userlogindto)
        {
            var usuarioLogin = await _usuarioRepository.Login(userlogindto);
            if (usuarioLogin == null)
            {
                return StatusCode(400, ModelState);
            }
            else
            {
                var usuarioLoginDto = _mapper.Map<UserLoginDto>(usuarioLogin);
                return usuarioLoginDto;
            }
        }

        /// <summary>
        /// REGISTRO INICIO
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        //[AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto usuarioRegisterDto)
        {
            var usuarioRegister = await _usuarioRepository.Register(usuarioRegisterDto);
            if (usuarioRegister != null)
            {
                return Ok();
            }
            else
                return BadRequest();
        }

        //[HttpPut]
        //public async Task<ActionResult<UserActualizarDto>> ActualizarUsuario(UserActualizarDto usuarioActualizarDto)
        //{
        //    var result = await _usuarioRepository.ActualizarUsuario(usuarioActualizarDto);
        //    if (result == null)
        //        return StatusCode(400, ModelState);
        //    else
        //        return result;
        //}

        //[HttpGet("DevolverUsuarioActual")]
        //public async Task<ActionResult<UserActualDto>> DevolverUsuarioActual()
        //{
        //    var result = await _usuarioRepository.ObtenerUsuarioActual();
        //    if (result == null)
        //        return StatusCode(400, ModelState);
        //    else
        //        return result;
        //}


        //***************************************************************************

        //[AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        //[AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();

        #region GET

        ///// <summary>
        ///// OBTIENE USUARIO
        ///// </summary>
        ///// <remarks>
        ///// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        ///// </remarks>
        ///// <param name="Idserdto">Objeto.</param>
        ///// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        //[RequireHttps]
        //[HttpGet("GetUsuarioAsync")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public UserDto GetUsuarioAsync(UserDto Idserdto)
        //{
        //    //String strId = Idserdto.Id;
        //    //var lstUser = _db.User.OrderByDescending(x => x.UsuarioAcceso).ToList();

        //    //if (lstUser == null)
        //    //{
        //    //    return null;
        //    //}

        //    //Int32 i = 0;
        //    //var personas = new UserDto();
        //    //foreach (var item in lstUser)
        //    //{
        //    //    if (item.Id.Trim() == Idserdto.Id.Trim())
        //    //    {
        //    //        personas.Id = lstUser[i].Id;
        //    //        personas.UserName = lstUser[i].UserName;
        //    //        personas.UsuarioAcceso = lstUser[i].UsuarioAcceso;
        //    //        personas.Email = lstUser[i].Email;
        //    //        personas.NIFUsuario = lstUser[i].NIFUsuario;
        //    //        personas.NombreUsuario = lstUser[i].NombreUsuario;
        //    //        personas.Apellidos = lstUser[i].Apellidos;
        //    //        personas.Domicilio = lstUser[i].Domicilio;
        //    //        personas.CP = lstUser[i].CP;
        //    //        personas.Poblacion = lstUser[i].Poblacion;
        //    //        personas.Provincia = lstUser[i].Provincia;
        //    //        personas.Pais = lstUser[i].Pais;
        //    //        personas.FechaAlta = lstUser[i].FechaAlta;
        //    //        personas.PhoneNumber = lstUser[i].PhoneNumber;
        //    //        personas.Movil = lstUser[i].Movil;
        //    //    }
        //    //    i++;
        //    //}
        //    //return personas;
        //    return null;
        //}

        ///// <summary>
        ///// OBTIENE LISTA USUARIOS
        ///// </summary>
        ///// <remarks>
        ///// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        ///// </remarks>
        ///// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        //[RequireHttps]
        //[HttpGet("ListarUsuariosIndex")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public List<UserDto> ListarUsuariosIndex()
        //{
        //    ////_bd.Cliente.OrderBy(c => c.NombreClienteID).ToListAsync();
        //    //var lstUsers = _db.Users.OrderBy(u => u.UsuarioAcceso).ToList();

        //    //List<UserDto> listaClienteDto = new List<UserDto>();
        //    //List<List<String>> listaDto = new List<List<String>>();

        //    //Int32 i = 0;
        //    //var personas = new List<UserDto>();
        //    //foreach (var item in lstUsers)
        //    //{
        //    //    personas.Add(new UserDto
        //    //    {
        //    //        Id = lstUsers[i].Id,
        //    //        UserName = lstUsers[i].UserName,
        //    //        UsuarioAcceso = lstUsers[i].UsuarioAcceso,
        //    //        Email = lstUsers[i].Email,
        //    //        NIFUsuario = lstUsers[i].NIFUsuario,
        //    //        NombreUsuario = lstUsers[i].NombreUsuario,
        //    //        Apellidos = lstUsers[i].Apellidos,
        //    //        Domicilio = lstUsers[i].Domicilio,
        //    //        CP = lstUsers[i].CP,
        //    //        Poblacion = lstUsers[i].Poblacion,
        //    //        Provincia = lstUsers[i].Provincia,
        //    //        Pais = lstUsers[i].Pais,
        //    //        FechaAlta = lstUsers[i].FechaAlta,
        //    //        PhoneNumber = lstUsers[i].PhoneNumber,
        //    //        Movil = lstUsers[i].Movil
        //    //    });
        //    //    i++;
        //    //}

        //    //return personas;

        //    //String s0 = lstUsers[0].UsuarioAcceso;
        //    //String s1 = lstUsers[0].Email;
        //    //String s2 = lstUsers[0].NIFUsuario;
        //    //String s3 = lstUsers[0].NombreUsuario;
        //    //String s4 = lstUsers[0].Apellidos;
        //    //String s5 = lstUsers[0].Domicilio;
        //    //String s6 = lstUsers[0].Poblacion;
        //    //String s7 = lstUsers[0].Provincia;
        //    //String s8 = lstUsers[0].Pais;
        //    //String s9 = lstUsers[0].PhoneNumber;
        //    //String s10 = lstUsers[0].Movil;
        //    ////var personas = new List<UserDto>();
        //    //personas.Add(new UserDto { UsuarioAcceso = s0, Email = s1 });

        //    //s0 = lstUsers[1].UsuarioAcceso;
        //    //s1 = lstUsers[1].Email;
        //    //s2 = lstUsers[1].NIFUsuario;
        //    //s3 = lstUsers[1].NombreUsuario;
        //    //s4 = lstUsers[1].Apellidos;
        //    //s5 = lstUsers[1].Domicilio;
        //    //s6 = lstUsers[1].Poblacion;
        //    //s7 = lstUsers[1].Provincia;
        //    //s8 = lstUsers[1].Pais;
        //    //s9 = lstUsers[1].PhoneNumber;
        //    //s10 = lstUsers[1].Movil;
        //    //personas.Add(new UserDto { UsuarioAcceso = s0, Email = s1 });







        //    //listaDto[0][0] = "aaaaaa";

        //    //listaClienteDto = (List<UserDto>)lstUsers;

        //    //foreach (var lista in lstUsers)
        //    //{
        //    //    listaClienteDto.Add(_mapper.Map<UserDto>(lista));
        //    //}
        //    //return listaClienteDto;

        //    //listaClienteDto.Insert(0, lstUsers);

        //    //String s0;
        //    //listaClienteDto[0].UsuarioAcceso = "aaa";

        //    //String s1;
        //    //String s2;
        //    //String s3;
        //    //String s4;
        //    //String s5;
        //    //String s6;
        //    //String s7;
        //    //String s8;
        //    //String s9;
        //    //String s10;

        //    //Int32 i = 0;
        //    //foreach (var lista in lstUsers)
        //    //{
        //    //    s0 = lstUsers[i].UsuarioAcceso;
        //    //    s1 = lstUsers[i].Email;
        //    //    s2 = lstUsers[i].NIFUsuario;
        //    //    s3 = lstUsers[i].NombreUsuario;
        //    //    s4 = lstUsers[i].Apellidos;
        //    //    s5 = lstUsers[i].Domicilio;
        //    //    s6 = lstUsers[i].Poblacion;
        //    //    s7 = lstUsers[i].Provincia;
        //    //    s8 = lstUsers[i].Pais;
        //    //    s9 = lstUsers[i].PhoneNumber;
        //    //    s10 = lstUsers[i].Movil;

        //    //    listaClienteDto.Add(lista);
        //    //    listaClienteDto[i].Email = s1;
        //    //    listaClienteDto[i].NIFUsuario = s2;
        //    //    listaClienteDto[i].NombreUsuario = s3;
        //    //    listaClienteDto[i].Apellidos = s4;
        //    //    listaClienteDto[i].Domicilio = s5;
        //    //    listaClienteDto[i].Poblacion = s6;
        //    //    listaClienteDto[i].Provincia = s7;
        //    //    listaClienteDto[i].Pais = s8;
        //    //    listaClienteDto[i].PhoneNumber = s9;
        //    //    listaClienteDto[i].Movil = s10;
        //    //    i++;
        //    //}
        //    //return personas;
        //    return null;
        //}

        ///// <summary>
        ///// OBTIENE LISTA USUARIOS AUTOCOMPLETAR ID-NOMBRE
        ///// </summary>
        ///// <remarks>
        ///// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        ///// </remarks>
        ///// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        ///// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        ///// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        //[RequireHttps]
        //[HttpGet("ListarUsuarios")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<List<UserDto>> ListarUsuarios()
        //{
        //    ////_bd.Cliente.OrderBy(c => c.NombreClienteID).ToListAsync();
        //    //var lstUsers = _db.Users.OrderBy(u => u.UsuarioAcceso).ToList();
        //    //List<List<IdentityRole>> lstRoles = new List<List<IdentityRole>>();
        //    //List<IdentityRole> lstRolesPorUser = new List<IdentityRole>();
        //    //Int32 i = 0;
        //    //foreach (var item in lstUsers)
        //    //{
        //    //    //lstRoles = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync());
        //    //    lstRolesPorUser = await _roleManager.Roles.Where(y => y.Id.Trim() == lstUsers[i].Id).OrderBy(x => x.Name).ToListAsync();
        //    //    lstRoles.Add(lstRolesPorUser);
        //    //}


        //    //List<UserDto> listaClienteDto = new List<UserDto>();
        //    //List<List<String>> listaDto = new List<List<String>>();

        //    //i = 0;
        //    //var personas = new List<UserDto>();
        //    //foreach (var item in lstUsers)
        //    //{
        //    //    personas.Add(new UserDto
        //    //    {
        //    //        Id = lstUsers[i].Id,
        //    //        UserName = lstUsers[i].UserName,
        //    //        UsuarioAcceso = lstUsers[i].UsuarioAcceso,
        //    //        Email = lstUsers[i].Email,
        //    //        NIFUsuario = lstUsers[i].NIFUsuario,
        //    //        NombreUsuario = lstUsers[i].NombreUsuario,
        //    //        Apellidos = lstUsers[i].Apellidos,
        //    //        Domicilio = lstUsers[i].Domicilio,
        //    //        CP = lstUsers[i].CP,
        //    //        Poblacion = lstUsers[i].Poblacion,
        //    //        Provincia = lstUsers[i].Provincia,
        //    //        Pais = lstUsers[i].Pais,
        //    //        FechaAlta = lstUsers[i].FechaAlta,
        //    //        PhoneNumber = lstUsers[i].PhoneNumber,
        //    //        Movil = lstUsers[i].Movil
        //    //        //Roles = lstRoles[i].
        //    //    });
        //    //    i++;
        //    //}
        //    //return personas;
        //    return null;
        //}

        //[RequireHttps]
        //[HttpGet("ObtenerListaUsuarios")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<List<UserDto>> ObtenerListaUsuarios()
        //{
        //    ////_bd.Cliente.OrderBy(c => c.NombreClienteID).ToListAsync();
        //    //List<ApplicationUser> lstUsers = new List<ApplicationUser>();
        //    //lstUsers = await _db.Users.OrderBy(u => u.UsuarioAcceso).ToListAsync();

        //    //List<UserDto> listaClienteDto = new List<UserDto>();
        //    //List<List<String>> listaDto = new List<List<String>>();

        //    //Int32 i = 0;
        //    //var personas = new List<UserDto>();
        //    //foreach (var item in lstUsers)
        //    //{
        //    //    personas.Add(new UserDto { UsuarioAcceso = lstUsers[i].UsuarioAcceso, Email = lstUsers[i].Email });
        //    //    i++;
        //    //}

        //    //return personas;
        //    return null;
        //}

        #endregion GET

        #region CRUD



        ///// <summary>
        ///// REGISTRAR UN USUARIO
        ///// </summary>
        ///// <param name="userDto"></param>
        ///// <returns></returns>
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[RequireHttps]
        ////[Authorize(Roles = "Adminstrador")]
        //[HttpPost("RegistrarUsuaro")]
        //[ProducesResponseType(201, Type = typeof(ExpedienteDto))]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> RegistrarUsuaro([FromBody] UserDto userDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest);
        //    }

        //    ////////////var user = new ApplicationUser
        //    ////////////{
        //    ////////////    //Id = userActual.Id,
        //    ////////////    UserName = userDto.Email,
        //    ////////////    Email = userDto.Email,
        //    ////////////    NormalizedEmail = userDto.NormalizedEmail,
        //    ////////////    //AccessFailedCount = userActual.AccessFailedCount,
        //    ////////////    //NormalizedUserName = userActual.NormalizedUserName,
        //    ////////////    //EmailConfirmed = userActual.EmailConfirmed,
        //    ////////////    //PasswordHash = userActual.PasswordHash,
        //    ////////////    //SecurityStamp = userActual.SecurityStamp,
        //    ////////////    //ConcurrencyStamp = ConcurrencyStamp,
        //    ////////////    PhoneNumber = userDto.PhoneNumber,
        //    ////////////    //PhoneNumberConfirmed = userActual.PhoneNumberConfirmed,
        //    ////////////    //TwoFactorEnabled = userActual.TwoFactorEnabled,
        //    ////////////    //LockoutEnd = userActual.LockoutEnd,
        //    ////////////    //LockoutEnabled = userActual.LockoutEnabled,
        //    ////////////    UsuarioAcceso = userDto.UsuarioAcceso,
        //    ////////////    NIFUsuario = userDto.NIFUsuario,
        //    ////////////    NombreUsuario = userDto.NombreUsuario,
        //    ////////////    Apellidos = userDto.Apellidos,
        //    ////////////    Domicilio = userDto.Domicilio,
        //    ////////////    CP = userDto.CP,
        //    ////////////    Poblacion = userDto.Poblacion,
        //    ////////////    Provincia = userDto.Provincia,
        //    ////////////    Pais = userDto.Pais,
        //    ////////////    Movil = userDto.Movil,
        //    ////////////    //Password = userActual.Password
        //    ////////////    //ConfirmPassword = userActual.ConfirmPassword,
        //    ////////////    FechaAlta = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")),
        //    ////////////    FechaUltimaConexion = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))
        //    ////////////    //iConectado = 0

        //    //////////};

        //    ////////////var user = new IdentityUser { UserName = usuario.Email, Email = usuario.Email };
        //    //////////var result = await _userManager.CreateAsync(user, userDto.Password);
        //    //////////if (result.Succeeded)
        //    //////////{
        //    //////////    if (!await _roleManager.RoleExistsAsync("SuperAdministrador"))
        //    //////////    {
        //    //////////        await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    //////////    }
        //    //////////    if (!await _roleManager.RoleExistsAsync("Administrador"))
        //    //////////    {
        //    //////////        await _roleManager.CreateAsync(new IdentityRole("Administrador"));
        //    //////////    }
        //    //////////    if (!await _roleManager.RoleExistsAsync("Empleado"))
        //    //////////    {
        //    //////////        await _roleManager.CreateAsync(new IdentityRole("Empleado"));
        //    //////////    }
        //    //////////    if (!await _roleManager.RoleExistsAsync("Socio"))
        //    //////////    {
        //    //////////        await _roleManager.CreateAsync(new IdentityRole("Socio"));
        //    //////////    }
        //    //////////    await _userManager.AddToRoleAsync(user, "Empleado");
        //    //////////    if (user.Email == "rogelio.borondo@gmail.com")
        //    //////////    {
        //    //////////        await _userManager.AddToRoleAsync(user, "Administrador");
        //    //////////        await _userManager.AddToRoleAsync(user, "SuperAdministrador");
        //    //////////    }
        //    //////////    return StatusCode(201);
        //    //////////}
        //    //////////foreach (var error in result.Errors)
        //    //////////{
        //    //////////    ModelState.AddModelError(string.Empty, error.Description);
        //    //////////}
        //    return StatusCode(400, ModelState);
        //    //return CreatedAtRoute("GetExpedienteAsync", new { ExpedienteID = expediente.ExpedienteID }, expediente);
        //}

        ///// <summary>
        ///// ELIMINAR UN USARIO EXISTENTE
        ///// </summary>
        ///// <param name="userDto"></param>
        ///// <returns></returns>
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[RequireHttps]
        ////[Authorize(Roles = "Adminstrador")]
        //[HttpDelete("BorrarUsuario")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> BorrarUsuario([FromBody] UserDto userDto)
        //{
        //    //////////if (userDto == null)
        //    //////////{
        //    //////////    return BadRequest(ModelState);
        //    //////////}
        //    //////////var currentUser = await _userManager.FindByIdAsync(userDto.Id);
        //    //////////string userID = userDto.Id;
        //    ////////////var saveUser = userStore.Context;
        //    ////////////await saveUser.SaveChangesAsync();
        //    //////////var userDel = await _userManager.FindByIdAsync(userID);


        //    //////////var rolesForUser = await _userManager.GetRolesAsync(currentUser);

        //    //////////if (rolesForUser.Count() > 0)
        //    //////////{
        //    //////////    foreach (var item in rolesForUser.ToList())
        //    //////////    {
        //    //////////        // item should be the name of the role
        //    //////////        var resultrol = await _userManager.RemoveFromRoleAsync(currentUser, item);
        //    //////////    }
        //    //////////}

        //    //////////var result = await _userManager.DeleteAsync(currentUser);
        //    //////////if (result.Succeeded)
        //    //////////{
        //    //////////    return Ok();
        //    //////////}
        //    //////////foreach (var error in result.Errors)
        //    //////////{
        //    //////////    ModelState.AddModelError(string.Empty, error.Description);
        //    //////////}
        //    return StatusCode(404, ModelState);
        //}

        #endregion CRUD

        #region ROLES


        /// <summary>
        /// OBTIENE LISTA ROLES
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su ID.
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //////[RequireHttps]
        ////////[Authorize(Roles = "Adminstrador")]
        //////[HttpGet("ListarRolesIndex")]
        //[ValidateAntiForgeryToken]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        ////////////[ProducesResponseType(StatusCodes.Status404NotFound)]
        //////////public async Task<List<IdentityRole>> ListarRolesIndex()
        //////////{
        //////////    //var roles = await _userManager.GetRolesAsync();
        //////////    //var userStore = new UserStore<ApplicationUser>(this._db);
        //////////    //////////List<IdentityRole> lstRoles = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync();
        //////////    //////////return lstRoles;
        //////////    //var appUser = await _userManager.FindByIdAsync(this.User.Identity.GetUserId());

        //////////    //IQueryable<Game> games = from membership in db.GameMemberships
        //////////    //                         where membership.ApplicationUserID == appUser.Id
        //////////    //                         join game in db.Games on membership.GameID equals game.ID
        //////////    //                         select game;
        //////////    //var adminRole = await db.Roles.FirstOrDefaultAsync(role => role.Name == "Admin");

        //////////    //this.ViewBag.Games = await games.ToListAsync();

        //////////    //this.ViewBag.Claims = await _userManager.GetClaimsAsync(appUser.Id);
        //////////    //this.ViewBag.Roles = await _userManager.GetRolesAsync(appUser.Id);

        //////////}

        ////////////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //////////[RequireHttps]
        ////////////[Authorize(Roles = "Adminstrador")]
        //////////[HttpPost("RolCrear")]
        //////////[ProducesResponseType(StatusCodes.Status201Created)]
        //////////[ProducesResponseType(StatusCodes.Status404NotFound)]
        //////////[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //////////public async Task<List<IdentityRole>> RolCrear([FromBody] VMRolUser roluser)
        //////////{
        //////////    if (!await _roleManager.RoleExistsAsync(roluser.RolNameUnico.Trim()))
        //////////    {
        //////////        await _roleManager.CreateAsync(new IdentityRole(roluser.RolNameUnico.Trim()));
        //////////    }
        //////////    List<IdentityRole> lstRoles = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync();
        //////////    return lstRoles;
        //////////}

        //////////[RequireHttps]
        //////////[HttpGet("RolNotInUser")]
        //////////public async Task<List<IdentityRole>> RolNotInUser([FromBody] VMRolUser roluser)
        //////////{
        //////////    //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        //////////    List<IdentityRole> lstRoles = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync();
        //////////    var appUser = await _userManager.FindByIdAsync(roluser.Id);
        //////////    //this.ViewBag.Claims = await _userManager.GetClaimsAsync(appUser);
        //////////    var rolesuser = await _userManager.GetRolesAsync(appUser);

        //////////    List<IdentityRole> devolver = new List<IdentityRole>(lstRoles);
        //////////    foreach (var item in lstRoles)
        //////////    {
        //////////        foreach (var itemuser in rolesuser)
        //////////        {
        //////////            if (item.Name.Trim() == itemuser.ToString().Trim())
        //////////            {
        //////////                //devolver.Add(item);
        //////////                devolver.Remove(item);
        //////////            }
        //////////        }
        //////////    }
        //////////    if (devolver != null)
        //////////        return devolver;
        //////////    else
        //////////        return null;


        ////////[RequireHttps]
        ////////[HttpGet("RolAreInUser")]
        ////////public async Task<List<IdentityRole>> RolAreInUser([FromBody] VMRolUser roluser)
        ////////{
        ////////    //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));
        ////////    List<IdentityRole> lstRoles = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync();
        ////////    var appUser = await _userManager.FindByIdAsync(roluser.Id);
        ////////    //this.ViewBag.Claims = await _userManager.GetClaimsAsync(appUser);
        ////////    var rolesuser = await _userManager.GetRolesAsync(appUser);

        ////////    List<IdentityRole> devolver = new List<IdentityRole>();
        ////////    foreach (var item in lstRoles)
        ////////    {
        ////////        foreach (var itemuser in rolesuser)
        ////////        {
        ////////            if (itemuser.ToString().Trim() == item.Name.Trim())
        ////////            {
        ////////                devolver.Add(item);
        ////////                //lstRoles.Remove(item);
        ////////            }
        ////////        }
        ////////    }
        ////////    if (devolver != null)
        ////////        return devolver;
        ////////    else
        ////////        return null;
        ////////}

        //////////////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        ////////////[RequireHttps]
        //////////////[Authorize(Roles = "Adminstrador")]
        ////////////[HttpPost("RolAsignarUser")]
        ////////////public async Task<IActionResult> RolAsignarUser([FromBody] VMRolUser roluser)
        ////////////{
        ////////////    var appUser = await _userManager.FindByIdAsync(roluser.Id);
        ////////////    var result = await _userManager.AddToRoleAsync(appUser, roluser.NameRol[0]);
        ////////////    if (result.Succeeded)
        ////////////        return Ok();
        ////////////    else
        ////////////    {
        ////////////        var err = result.Errors;
        ////////////        return StatusCode(400);
        ////////////    }
        ////////////}

        //////////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        ////////[RequireHttps]
        //////////[Authorize(Roles = "Adminstrador")]
        ////////[HttpPost("RolEliminarUser")]
        ////////public async Task<IActionResult> RolEliminarUser([FromBody] VMRolUser roluser)
        ////////{
        ////////    var appUser = await _userManager.FindByIdAsync(roluser.Id);
        ////////    var resultrol = await _userManager.RemoveFromRoleAsync(appUser, roluser.NameRol[0]);
        ////////    if (resultrol.Succeeded)
        ////////        return Ok();
        ////////    else
        ////////        return NotFound(404);
        ////////}

        #endregion ROLES


    }
}
