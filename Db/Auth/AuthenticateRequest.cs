using System.ComponentModel.DataAnnotations;

namespace Db.Auth
{
    public class AuthenticateRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}