using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Db.IRepository;
using Db.Models;
using Db.Models.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FacultyApi.Auth
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>()
        {
            new User() {UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), Login = "User", Password = "1234", Role = "User"},
            new User() {UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9"), Login = "Admin", Password = "1111", Role = "Admin"}
        };

        public UserService()
        {
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Login == model.Login && x.Password == model.Password);
            if (user == null) return null;

            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
        
        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }

        private string GenerateJwtToken(User user)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}