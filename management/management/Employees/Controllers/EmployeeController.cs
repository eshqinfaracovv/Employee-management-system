using management.Employees.Contexts;
using management.Employees.Databasefor;
using management.Employees.Models;
using management.Employees.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace management.Employees.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet("List", Name = "Employee-list")]
        public IActionResult List()
        {
         using DataContext context=new DataContext();

            var employee = context.Employees
               .Select(e  => new ListViewModel(e.Name, e.LastName, e.FatherName, e.CreatedAt,e.Soft==false))
               .ToList();
     
           

            return View("~/Employees/Views/v_Employe/List.cshtml", employee);


        }
        [HttpGet("add", Name = "Employee-add")]
        public IActionResult Add()
        {
            return View("~/Employees/Views/v_Employe/Add.cshtml");
        }
        [HttpPost("add", Name = "Employee-add-model")]
        public IActionResult Add(AddViewModel Employee)
        {
            using DataContext context = new DataContext();
            var employee = context.Employees
              .Select(e => new AddViewModel(e.Name,e.LastName,e.FINCode,e.Email,e.FatherName))
              .ToList();
            if (!ModelState.IsValid)
            {
                return View("~/Employees/Views/v_Employe/Add.cshtml", Employee);
            }

            context.Employees.Add(new Employee
            {
                Name = Employee.Name,
                LastName = Employee.LastName,
                FINCode = Employee.FINCode,
                Email = Employee.Email,
                FatherName = Employee.FatherName,
                EmployeeCode= TableAutoGenerateEmployeeCode.RandomEmpCode,               
            });
            context.SaveChanges();
            return RedirectToRoute("Employee-list");
        }



        [HttpGet("Delete/{id}", Name = "Employee-Delete-id")]
        public IActionResult Delete(int id)
        {
            using DataContext context = new DataContext();
            var employee = context.Employees.FirstOrDefault(e => e.Id == id);


            if (employee is null)
            {
                return NotFound();
            }

           context.Remove(employee);
            context.SaveChanges();



            return RedirectToRoute("Employee-List");
        }


    }
}
