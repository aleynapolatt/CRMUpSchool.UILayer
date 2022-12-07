using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class RegisterController : Controller
    {
        //dependcy injections 

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            //mimariye bağımlı değil identity üzerinden gidiliyor
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);
            /* async aynı anda birçok işlemi yapma
          method da async olmalı o yüzden public in yanına yazdık */
            // await yazmazsak Succed gelmiyordu -- await bekleme yapmadan return sağlar
            /*neden bir daha passwordhash aldık hanizaten appUser class var passwordda 
            ,appUser.PasswordHash) bunu yazmadan da sistemem çalıştı olay useralmadaydı
            */
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index2(UserSignUpModel p)
        {
            if (ModelState.IsValid) { 
            AppUser appUser = new AppUser()
            {
                UserName = p.Username,
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.Phonenumber,


            };
            if (p.Password==p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); //sadece identity görüyor
                    }

                }
            }
            else
            {
                ModelState.AddModelError("", "passwords do not match");
            }
            }
         
            return View();
        }

    }
}
