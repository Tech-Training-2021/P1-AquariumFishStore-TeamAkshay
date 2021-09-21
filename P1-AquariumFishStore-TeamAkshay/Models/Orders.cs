using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name:")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public  string Username { get; set; }
        [DisplayName("Product Name:")]
        [Required(ErrorMessage = "Product Name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public  string Productname { get; set; }
        [DisplayName("Location:")]
        [Required(ErrorMessage = "Location is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]
        public  string Location { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please give Quantity in numbers.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please give price in numbers.")]
        public decimal TotalPrice { get; set; }

       

        

        
    }
}