using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int ? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MemberShipTypeID { get; set; }
        [Display(Name = "Date of Birth")]
        //[Min18YearsIfaMember(ErrorMessage = "You should be atleast 18 years of age for the membership")]
        public DateTime? Birthdate { get; set; }

    }
}