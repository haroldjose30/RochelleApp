﻿using System;
namespace RochelleShared.Models
{
    public class Login:EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public RegisterState State { get; set; }
    }


}