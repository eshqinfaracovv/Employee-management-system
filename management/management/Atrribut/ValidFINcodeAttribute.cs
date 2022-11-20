using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace management.Utilities
{
    public class ValidFINcodeAttribute : ValidationAttribute
    {
    
        protected override ValidationResult IsValid(object? value,ValidationContext validationContext)
        {
         string fin=value.ToString();
           
            if (Regex.IsMatch(fin, @"^[A-Z0-9]{7}$"))
            {
                    return ValidationResult.Success;
                }
            return new ValidationResult("FinCode Is Not Correct");
        }

       


    }
}
