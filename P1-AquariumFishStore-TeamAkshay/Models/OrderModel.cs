using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
   
    public class OrderModel
    {
        public int Order { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
    }

}