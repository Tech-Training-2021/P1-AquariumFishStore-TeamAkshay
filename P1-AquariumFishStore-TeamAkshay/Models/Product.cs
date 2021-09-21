using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class Product
    {
       [Key]
        public int Id { get; set; }


        [DisplayName("Product Name:")]
        [Required(ErrorMessage = "Product Name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]


        public string Name { get; set; }
        [Required(ErrorMessage = "Product type is required.")]
       
        public string ProductType { get; set; }


        [DisplayName("Location ")]
        [Required(ErrorMessage = "Location is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets are allowed.")]


        public string Location { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please give Quantity in numbers.")]
        public int Quantity { get; set; }
       

       [Required(ErrorMessage = "Price is required.")]
       [RegularExpression(("^[0-9]{11}$"),
        ErrorMessage = "Price shoul be in numbers.")]
        public decimal Price { get; set; }
    }
}