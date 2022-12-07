using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeTaskController : Controller
    {
        //dependcy injection
        private readonly IEmployeeTaskService _employeeTaskService;
        //user tablosunun servis değeri
        private readonly UserManager<AppUser> _userManager;
        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, UserManager<AppUser> userManager)
        {
            _employeeTaskService = employeeTaskService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //önce verilen gelmesi 
            var values = _employeeTaskService.TGetEmployeeTaskByEmployee();
            return View(values);
        }

        [HttpGet]
   
        public IActionResult AddTask()
        {
            List<SelectListItem> userValues = (from x in _userManager.Users.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name +" "+ x.Surname,
                                                       Value = x.Id.ToString()
                                                   }).ToList(); //thy uçuşlarındaki dragdownlar
            ViewBag.v = userValues;

            return View();
        }


        [HttpPost]
        public IActionResult AddTask(EmployeeTask employeeTask) 
        {
            employeeTask.Status = "Görev Atandı";
            employeeTask.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //method ismi farklı -- aspection (?)
            _employeeTaskService.TInsert(employeeTask);
            return View("Index");
        }
    }
}
