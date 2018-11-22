using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobsPortal.ViewModels.CustomValidation
{
    public sealed class MaxPaymentGreatherThenMin : ValidationAttribute
    {
        private string _minPaymentPropertyName;

        public MaxPaymentGreatherThenMin(string minPaymentPropertyName)
        {
            _minPaymentPropertyName = minPaymentPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_minPaymentPropertyName);
            var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

            if ((decimal)value > (decimal)propertyValue)
            {
                return ValidationResult.Success;
            }
            else
            {
                 return new ValidationResult("Płaca minimalna nie może być większa od płacy maksymalnej");
            }
        }

    }
}