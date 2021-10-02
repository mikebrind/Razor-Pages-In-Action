using System.ComponentModel.DataAnnotations;

namespace CityBreaks.ValidationAttributes
{
    public class UploadFileExtensionsAttribute : ValidationAttribute
    {
        private IEnumerable<string> allowedExtensions; 
        public string Extensions { get; set;  }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            allowedExtensions = Extensions?
                .Split(new char[] { ',' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLowerInvariant());
            if (value is IFormFile file && allowedExtensions.Any())
            {
                var extension = Path.GetExtension(file.FileName.ToLowerInvariant());
                if (!allowedExtensions.Contains(extension))
                {
                    return new ValidationResult(ErrorMessage
                        ?? $"The file extension must be {Extensions}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
