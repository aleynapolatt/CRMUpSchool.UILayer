using CrmUpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                //conetxt methodları geliyor 
                ViewBag.EmployeeCount = context.Employees.Count();
                ViewBag.EmployeeWomanGenderCount = context.Users.Where(x => x.Gender == "Female").Count();
                //AppUser neden gelmedi? Ana tablomuz user /AppUser(class) geçiçi ek / Context e AppUserı tanımlamadık. 
                int id = context.Users.Max(x => x.Id);
                ViewBag.LastUser = context.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
                //Tag metodu dönen değerler içerisindeki ilkini alma 
            }

            return View();
        }
    }
}
