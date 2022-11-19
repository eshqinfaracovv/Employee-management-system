namespace management.Employees.ViewModels
{
    public class UpdateViewModel
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
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
