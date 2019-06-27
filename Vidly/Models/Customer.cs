using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MemberShipTypeID { get; set; }
        [Display(Name="Date of Birth")]
        //[Min18YearsIfaMember (ErrorMessage ="You should be atleast 18 years of age for the membership")]
        public DateTime ? Birthdate { get; set; }
        
    }
}