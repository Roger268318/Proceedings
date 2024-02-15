namespace Proceedings.Identity.BussinessObjects.Dtos.Identity
{
    public class UserLoginDto
    {
        public string? UserAccess { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }

        public List<string>? Roles { get; set; }

        //public HttpStatusCode httpReturnStatusCodeUtil { get; set; }
        //public List<Errors> Errors { get; set; }
    }
}
