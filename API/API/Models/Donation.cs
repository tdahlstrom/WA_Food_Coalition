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
        
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Phone")]
        public String Phone { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public Double Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public Double Longitude { get; set; }

        /* Brandon - Description field for type of food, amount of food, etc. */
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public String Status { get; set; }

        [Required]
        [Display(Name = "ExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "FoodBankID")]
        public int FoodBankID { get; set; }
    }

    public class DonationDistanceResult : Donation
    {
        [Required]
        [Display(Name = "Distance")]
        public Double Distance { get; set; }
    }

    public enum StatusType {
        Open,
        Pending,
        Closed
    }
}