using management.Employees.Models.Common;
using System;

namespace management.Employees.Models
{
    public class Employee : Entity<int>
    {
       
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string EmployeeCode { get; set; }
        public string Email { get; set; }
        public string FINCode { get; set; }
        public bool Soft { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}
