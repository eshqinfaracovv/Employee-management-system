namespace management.Employees.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
       

        //public ListViewModel(string name, string lastName, string fatherName, string employeeCode, DateTime createdAt)
        //    : base(name, lastName, fatherName, employeeCode, createdAt)
        //{
        //    Name = name;
        //    LastName = lastName;
        //    FatherName = fatherName;
        //    EmployeeCode = employeeCode;
        //    CreatedAt = createdAt;
        //}


        public string EmployeCode { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ListViewModel(string emloyecode, string name, string lastName, string fatherName, DateTime createdAt, bool soft)
            :base(name, lastName, fatherName)
        {
            EmployeCode = emloyecode;
      
            CreatedAt = createdAt;
            IsDeleted = soft;


        }
        public ListViewModel()
        {

        }




    }
}
