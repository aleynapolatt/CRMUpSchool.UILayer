using CrmUpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        //area nasıl ayağa kalkar?
        //öncelikle info kısmını gidip startup a ekledik 
        //sonrasında da alanı belirttik area yı çağırdık 
        //sorun şu isimlendirmede area ile controller aynı olunca url adı saçma oluyor

        private readonly UserManager<AppUser> _userManager;

        public EmployeeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name;
            ViewBag.v2 = values.Surname;
            return View();
        }
    }
}
