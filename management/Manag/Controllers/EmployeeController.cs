using management.Employees.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Manag.Controllers
{
    public class EmployeeController : management.Employees.Controllers.EmployeeController
    {
        public override IActionResult List()
        {
            return base.List();
        }
    }
}
