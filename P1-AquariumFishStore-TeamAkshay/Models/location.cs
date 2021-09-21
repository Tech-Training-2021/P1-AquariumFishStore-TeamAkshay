using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P1_AquariumFishStore_TeamAkshay.Models
{
    public class location
    {
        public int Id { get; set; }
        [DisplayName("Location :")]
        [Required]
        [StringLength(50)]
        public string Branch { get; set; }

    }
}