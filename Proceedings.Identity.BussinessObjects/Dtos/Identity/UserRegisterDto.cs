﻿namespace Proceedings.Identity.BussinessObjects.Dtos.Identity
{
    public class UserRegisterDto
    {
        public string? UserCreate { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? Token { get; set; }
    }
}