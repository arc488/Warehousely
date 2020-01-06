using System;
using System.ComponentModel.DataAnnotations;

namespace Helpers
{
    public class DateIsTodayOrFuture : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = DateTime.Compare((DateTime)value, DateTime.Today);
            if (result < 0)
            {
                return new ValidationResult("Date cannot be in the past");
            };

            return ValidationResult.Success;

        }
    }
}
