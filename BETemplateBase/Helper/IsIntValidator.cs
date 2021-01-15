using System.ComponentModel.DataAnnotations;

namespace Helper
{
    public class IsIntValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = int.TryParse(value.ToString(), out _);

            if (!result)
            {
                return new ValidationResult(validationContext.DisplayName + " format invalid");
            }

            return ValidationResult.Success;
        }
    }
}
