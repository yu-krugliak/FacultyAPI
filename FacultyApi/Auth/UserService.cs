using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Db.IRepository;
using Db.Models;
using Db.Models.Students;
using FacultyApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        private readonly AuthOptions _authOptions;

        public UserService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
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
            if (_authOptions.Secret == null)
            {
                throw new ArgumentNullException(nameof(_authOptions.Secret));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}