﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Min18YearsIfaMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer=(Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeID == MembershipType.PayAsYouGo || customer.MemberShipTypeID==MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success :
                new ValidationResult("Customer should be atleast 18 years old to go on membership ");
        }
    }
}