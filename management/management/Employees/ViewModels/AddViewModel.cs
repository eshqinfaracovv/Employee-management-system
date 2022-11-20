using management.Utilities;
using System.ComponentModel.DataAnnotations;

namespace management.Employees.ViewModels
{
    public class AddViewModel  /*BaseViewModel*/
    {
        //public string Email { get; set; }
        //public string FINCode { get; set; }
        //public AddViewModel(string name, string lastName, string fatherName,  string email,string fincode)
        //    :base(name,lastName,fatherName)
        //{
        //    Email = email;
        //    FINCode=fincode;

        //}

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

        public AddViewModel(string name,string lastname,string fathername,string email,string fincode)
        {
            Name = name;
            LastName = lastname;
            FatherName = fathername;
            Email = email;
            FINCode=fincode;

        }
        public AddViewModel()
        {

        }
    }
}
