using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    } 
    public class CustomerAddViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeID { get; set; }
        [Display(Name = "Date of Birth")]
        //[Min18YearsIfaMember (ErrorMessage ="You should be atleast 18 years of age for the membership")]
        public DateTime? Birthdate { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}