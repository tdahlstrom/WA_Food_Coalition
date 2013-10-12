using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Spatial;

namespace API.Models
{
    public class Donation
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Amount of Food")]
        public string FoodAmount { get; set; }

        [Required]
        [Display(Name = "Type of Food")]
        public string FoodType { get; set; }

        //[Required]
        //[Display(Name = "Location")]
        //public DbGeography Location { get; set; }
    }

    public class DonationDBContext : DbContext
    {
        public DonationDBContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Donation> Donations { get; set; }
    }
}