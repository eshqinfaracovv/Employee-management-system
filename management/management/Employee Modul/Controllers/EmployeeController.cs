using management.Contexts;
using management.Employees.Models;
using management.Employees.Utilities;
using management.Employees.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace management.Employees.Controllers
{
    [Route("/Employee")]
    public class EmployeeController : Controller

    {
        [Route("")]
        [HttpGet("List", Name = "Employee-list")]
        [Route("~/")]
        public virtual IActionResult List()
        {
            using DataContext context = new DataContext();

            var employee = context.Employees
               .Select(e => new ListViewModel(e.EmployeeCode, e.Name, e.LastName, e.FatherName, e.CreatedAt, e.Soft))
               .ToList();



            return View("~/Employee Modul/Views/v_Employe/List.cshtml", employee);


        }
        [HttpGet("add", Name = "Employee-add")]
        public IActionResult Add()
        {
            return View("~/Employee Modul/Views/v_Employe/Add.cshtml");
        }
        [HttpPost("add", Name = "Employee-add-model")]
        public IActionResult Add([FromForm]AddViewModel Employee)
        {
            using DataContext context = new DataContext();
            var employee = context.Employees
              .Select(e => new AddViewModel(e.Name, e.LastName, e.FINCode, e.Email, e.FatherName))
              .ToList();
            if (!ModelState.IsValid)
            {
                return View("~/Employee Modul/Views/v_Employe/Add.cshtml", Employee);
            }

            context.Employees.Add(new Employee
            {
                EmployeeCode = TableAutoGenerateEmployeeCode.RandomEmpCode,
                Name = Employee.Name,
                LastName = Employee.LastName,
                FINCode = Employee.FINCode,
                Email = Employee.Email,
                FatherName = Employee.FatherName,
            });

            context.SaveChanges();
            return RedirectToRoute("Employee-list");
        }



        [HttpGet("Delete/{EmployeeCode}", Name = "Employee-Delete-id")]
        public IActionResult Delete([FromRoute]string EmployeeCode)
        {
            using DataContext context = new DataContext();
            var employee = context.Employees.FirstOrDefault(e => e.EmployeeCode == EmployeeCode);

            if (employee is null)
            {
                return NotFound();
            }
            employee.Soft = true;
            context.SaveChanges();
            return RedirectToRoute("Employee-List");
        }

        [HttpGet("update/{EmployeeCode}", Name = "Employee-update-id")]
        public IActionResult Update([FromRoute] string EmployeeCode)
        {
            using DataContext context = new DataContext();
            var Employee = context.Employees.FirstOrDefault(e => e.EmployeeCode == EmployeeCode);
            if (Employee == null)
            {
                return NotFound();
            }

            return View("~/Employee Modul/Views/v_Employe/Update.cshtml", new UpdateViewModel
            {
                Name = Employee.Name,
                LastName = Employee.LastName,
                FatherName = Employee.FatherName,
                Email = Employee.Email,
                FINCode = Employee.FINCode
            });
        }
        [HttpPost("update/{EmployeeCode}", Name = "Employee-update")]
        public IActionResult Update([FromForm] UpdateViewModel model)
        {
            using DataContext context = new DataContext();
            var Employee = context.Employees.FirstOrDefault(e => e.EmployeeCode == model.EmployeeCode);
            if (Employee == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View("~/Employee Modul/Views/v_Employe/Update.cshtml", model);
            }

            Employee.Name = model.Name;
            Employee.LastName = model.LastName;
            Employee.FatherName = model.FatherName;
            Employee.Email = model.Email;
            Employee.FINCode = model.FINCode;
            context.SaveChanges();
            return RedirectToAction(nameof(List));

        }
    }
}
