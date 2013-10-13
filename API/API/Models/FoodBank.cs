using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models {
    public class FoodBank {
        
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        
        [Required]
        public long rangeInMeters { get; set; }

        [Display(Name = "Latitude")]
        public Double Latitude { get; set; }

        [Display(Name = "Longitude")]
        public Double Longitude { get; set; }

        // More fields to be defined later
    }

    public class FoodBankDistanceResult : FoodBank
    {
        [Display(Name = "Distance")]
        public Double Distance { get; set; }
    }
}