using CrmUpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous] // her yer şuanda authentication isterken bu sayfayı özel kıldık ki kullacını giriş sayfasına erişsin diğer türlü 404.15 hata kodu
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(AppUser appUser)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);
            //çerezlere kaydolsun mu? = false // yanlış girince kilitlensin mi?= true
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
