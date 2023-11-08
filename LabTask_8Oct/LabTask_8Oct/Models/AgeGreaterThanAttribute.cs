using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask_8Oct.Models
{
    public class AgeGreaterThanAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public AgeGreaterThanAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dob)
            {
                var today = DateTime.Today;
                var age = today.Year - dob.Year;
                if (dob > today.AddYears(-age)) age--;

                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Age must be greater than {_minimumAge}.");
        }
    }
}