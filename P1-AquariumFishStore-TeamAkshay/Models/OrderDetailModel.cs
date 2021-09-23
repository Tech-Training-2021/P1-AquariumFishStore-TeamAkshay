using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class OrderDetailModel
    {
        [Key]
        [DisplayName("Order Detail Id")]
        public int OrderDetailId { get; set; }
        [DisplayName("Order Id")]
        public int OrderId { get; set; }
        [DisplayName("Product Id")]
        public int ProductId { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Total Price")]
        public decimal Total { get; set; }
    }
}