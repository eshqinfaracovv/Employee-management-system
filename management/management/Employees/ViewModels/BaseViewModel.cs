using System.ComponentModel.DataAnnotations;

namespace management.Employees.ViewModels
{
    public class BaseViewModel
    {

        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Some Things is Incorrect Please Check Lenght and Other things")]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Some Things is Incorrect Please Check Lenght and Other things")]
        [Required]
        public string LastName { get; set; }
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "Some Things is Incorrect Please Check Lenght and Other things")]
        [Required]
        public string FatherName { get; set; }
        public BaseViewModel(string name, string lastName, string fatherName)
        {
            Name = name;
            LastName = lastName;
            FatherName = fatherName;
        }
        public BaseViewModel()
        {

        }
    }
}
