﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LogInProject.Models
{
	public class LoginViewModel
	{
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}

