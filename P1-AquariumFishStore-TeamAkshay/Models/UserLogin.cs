using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        public int roleId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}