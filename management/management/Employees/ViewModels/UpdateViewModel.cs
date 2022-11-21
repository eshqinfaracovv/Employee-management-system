using management.Atrributs;
using System.ComponentModel.DataAnnotations;

namespace management.Employees.ViewModels
{
    public class UpdateViewModel : BaseViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [ValidFINcodeAttribute]
        public string FINCode { get; set; }
        public string EmployeeCode { get; set; }

        public UpdateViewModel(string name, string lastname, string fathername, string email, string fincode,string employeecode)
            :base(name,lastname,fathername)
        {
            Email = email;
            FINCode = fincode;
            EmployeeCode = employeecode;
        }
        public UpdateViewModel()
        {
        }
    }
}
