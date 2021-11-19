﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Models.Auth
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}