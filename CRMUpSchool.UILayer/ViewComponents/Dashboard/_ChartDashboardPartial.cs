using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _ChartDashboardPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //Invoke methodunda add view yok partial tanımlanması olayı
            List<DepartmentSalary> departmantSalaries = new List<DepartmentSalary>();

            return View();
        }
    }
}
