using Db.Models.Auth;
using System;

namespace Db.Auth
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
            Token = token;
        }
    }
}