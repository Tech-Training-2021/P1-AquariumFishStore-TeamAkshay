using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class category
    {
        
        public int Id { get; set; }
        [DisplayName("Category :")]
        [Required]
        [StringLength(30)]
        
        public string Category { get; set; }
    }
}