using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown || customer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult(" Birthday is required ");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            var lapse = 18 - age;
            return (age >= 18) ? ValidationResult.Success :  new ValidationResult(" Sorry, You are not old enough to subcribe to this plan. Try again in the next  " + lapse + " Year(s)");
        }
    }
}