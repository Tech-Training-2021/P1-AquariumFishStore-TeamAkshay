using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("Name:")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        ErrorMessage = "Invalid Email.")]
        public string email { get; set; }


        public string role { get; set; }

       
        public string gender { get; set; }

        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
        ErrorMessage = "Password should contain 8 character - one uppercase, one lowercase, one numeric value and a special character.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression("^[0-9]{10}$",
        ErrorMessage = "Phone number should have 10 digits only")]
        public string mobileNo { get; set; }

    }
}