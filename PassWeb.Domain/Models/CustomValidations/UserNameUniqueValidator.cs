using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PassWeb.Domain.Models.CustomValidations
{
    public class UserNameUniqueValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            else
            {

            }
        }
    }
}
