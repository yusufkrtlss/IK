﻿using System.ComponentModel.DataAnnotations;

namespace IK.Models
{
    public class SignUpViewModel
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please Enter your E-mail")]
        public string Mail { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter your Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter your Phone")]
        public string Phone { get; set; }

    }
}
