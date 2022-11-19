﻿using management.Employees.Contexts;
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
            using DataContext context = new DataContext();

            var employee = context.Employees
               .Select(e => new ListViewModel(e.EmployeeCode, e.Name, e.LastName, e.FatherName, e.CreatedAt, e.Soft))
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
              .Select(e => new AddViewModel(e.Name, e.LastName, e.FINCode, e.Email, e.FatherName))
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
                EmployeeCode = TableAutoGenerateEmployeeCode.RandomEmpCode,
            });
            context.SaveChanges();
            return RedirectToRoute("Employee-list");
        }



        [HttpGet("Delete/{EmployeeCode}", Name = "Employee-Delete-id")]
        public IActionResult Delete(string EmployeeCode)
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
        public IActionResult Update(string EmployeeCode)
        {
            using DataContext context = new DataContext();
            var Employee = context.Employees.FirstOrDefault(e => e.EmployeeCode == EmployeeCode);
            if (Employee == null)
            {
                return NotFound();
            }

            return View("~/employees/Views/v_Employe/Update.cshtml", new UpdateViewModel
            {
                Name = Employee.Name,
                LastName = Employee.LastName,
                FatherName = Employee.FatherName,
                Email = Employee.Email,
                FINCode = Employee.FINCode
            });
        }
        [HttpPost("update/{EmployeeCode}", Name = "Employee-update")]
        public IActionResult Update(UpdateViewModel model)
        {
            using DataContext context = new DataContext();
            var Employee = context.Employees.FirstOrDefault(e => e.EmployeeCode == model.EmployeeCode);
            if (Employee == null)
            {
                return NotFound();
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