using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WA_Food_Coalition.Models
{
    public class ContactInfo
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }

    public class ContactInfoDBContext : DbContext
    {
        public ContactInfoDBContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}