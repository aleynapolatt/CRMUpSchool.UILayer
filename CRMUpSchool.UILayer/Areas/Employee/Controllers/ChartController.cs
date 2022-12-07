using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DepartmentChart()
        {
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Muhasebe",
                salaryavg=10000
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "IT",
                salaryavg = 20000
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Satış",
                salaryavg = 12000
            });
            return Json(new { jsonList = departmentSalaries });
        }
    }
}
