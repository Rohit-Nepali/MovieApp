﻿using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.AuthVM
{
    public class SignUp
    {
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
