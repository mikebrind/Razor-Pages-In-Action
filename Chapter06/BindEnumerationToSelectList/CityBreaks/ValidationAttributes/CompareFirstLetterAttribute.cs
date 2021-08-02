using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CityBreaks.ValidationAttributes
{
    public class CompareFirstLetterAttribute : ValidationAttribute
    {
        public string OtherProperty { get; set; }
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult("You must specify another property to compare to");
            }
            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (!string.IsNullOrWhiteSpace(value?.ToString()) &&
                    !string.IsNullOrWhiteSpace(otherValue?.ToString()) &&
                    value.ToString().ToLower().First() != otherValue.ToString().ToLower().First())
            {
                return new ValidationResult(ErrorMessage
                ?? $"The first letters of {validationContext.DisplayName} and {otherPropertyInfo.Name} must match");
            }
            return ValidationResult.Success;
        }
    }
}
