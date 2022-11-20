using management.Utilities;
using System.ComponentModel.DataAnnotations;

namespace management.Employees.ViewModels
{
    public class UpdateViewModel
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
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [ValidFINcodeAttribute]
        public string FINCode { get; set; }
        public string EmployeeCode { get; set; }

        public UpdateViewModel(string name, string lastname, string fathername, string email, string fincode,string employeecode)
        {
            Name = name;
            LastName = lastname;
            FatherName = fathername;
            Email = email;
            FINCode = fincode;
            EmployeeCode = employeecode;


        }
        public UpdateViewModel()
        {

        }
    }
}
