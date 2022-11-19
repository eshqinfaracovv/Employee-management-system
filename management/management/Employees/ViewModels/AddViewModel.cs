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


        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        
        public string Email { get; set; }
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
