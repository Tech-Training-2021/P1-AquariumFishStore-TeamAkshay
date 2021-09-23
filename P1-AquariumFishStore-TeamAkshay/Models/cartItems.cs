using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class cartItems
    {
        public int Id { get; set; }

        public int? LocationId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public string Location { get; set; }

        public string Product { get; set; }

        public string customer { get; set; }
    }
}