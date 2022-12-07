using CrmUpSchool.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")] //olmasa çalıştırmazdı EmployeeTaskListByProfile sayfasını 
    public class EmployeeTaskDetailController : Controller
    {
        private readonly IEmployeeTaskDetailService _employeeTaskDetailService;

        public EmployeeTaskDetailController(IEmployeeTaskDetailService employeeTaskDetailService)
        {
            _employeeTaskDetailService = employeeTaskDetailService;
        }

        public IActionResult Index(int id)
        {
            var values = _employeeTaskDetailService.GetEmployeeTaskDetailById(id);
            return View(values);
        }
    }
}
