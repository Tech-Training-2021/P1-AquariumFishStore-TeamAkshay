using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class changePassword
    {
        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter correct email address")]
        [DisplayName("Email :")]
        public string email { get; set; }

        [DisplayName("Old Pasword :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Oldpassword { get; set; }

        [DisplayName("Password :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
         ErrorMessage = "Password should contain 8 character - one uppercase, one lowercase, one numeric value and a special character.")]

        public string password { get; set; }

        [DisplayName("Confirm Password :")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string cPassword { get; set; }

    }
}