using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace LabTask_8Oct.Models
{
    public class MatchingIdEmailAttribute : ValidationAttribute
    {
        private readonly string _idPropertyName;

        public MatchingIdEmailAttribute(string idPropertyName)
        {
            _idPropertyName = idPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var idProperty = validationContext.ObjectType.GetProperty(_idPropertyName);

            if (idProperty == null)
            {
                return new ValidationResult($"Unknown property: {_idPropertyName}");
            }

            var idValue = (string)idProperty.GetValue(validationContext.ObjectInstance, null);
            var emailValue = (string)value;

            if (idValue == emailValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The {validationContext.DisplayName} must match the {idProperty.Name}.");
        }
    }
    






}