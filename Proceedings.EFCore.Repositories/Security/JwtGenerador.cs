

namespace Proceedings.EFCore.Repositories.Security
{
    public class JwtGenerador : IJwtGenerador
    {
        private readonly IConfiguration _configuration;

        public JwtGenerador(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CrearToken(ApplicationUser usuario, List<string> lstRoles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName)
            };
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));

            foreach (var rolName in lstRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rolName));
            }
            ////////////var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            ////////////var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            ////////////var tokenDescriptor = new SecurityTokenDescriptor
            ////////////{
            ////////////    Subject = new ClaimsIdentity(claims),
            ////////////    //Fecha de expiración del Token
            ////////////    Expires = DateTime.UtcNow.AddDays(30),
            ////////////    SigningCredentials = credentials
            ////////////};
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var tokenManejador = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenManejador);
            return token;

            //////////var tokenManejador = new JwtSecurityTokenHandler();
            //////////var token = tokenManejador.CreateToken(tokenDescriptor);
            //////////return tokenManejador.WriteToken(token);
        }
    }

    //private String CreateToken(IdentityUser user, IList<string> roles)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));   // Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
    //    var claim = new List<Claim>();
    //    {
    //        new Claim(ClaimTypes.NameIdentifier, user.Id);
    //    };
    //    foreach (var rolName in roles)
    //    {
    //        claim.Add(new Claim(ClaimTypes.Role, rolName));
    //    }
    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(claim),
    //        //Fecha de expiración del Token
    //        Expires = DateTime.UtcNow.AddDays(7),
    //        SigningCredentials = creds
    //    };

    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    return tokenHandler.WriteToken(token);
    //}
}
