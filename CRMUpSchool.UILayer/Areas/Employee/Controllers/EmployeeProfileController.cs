using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController: Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfile userEditProfile = new UserEditProfile();

            userEditProfile.Name = values.Name;
            userEditProfile.Surname = values.Surname;
            userEditProfile.Phonenumber = values.PhoneNumber; //Appuser tarafından geliyor values
            userEditProfile.Email = values.Email;
            return View(userEditProfile);
        }
        //1. Html tarafındaki kısıtlamalarla backend trafaındaki kısıtlamalarda ne fark var?
        //Değişken adlarının b/k harf olması ne farkı var
        [HttpPost]
        public async Task<IActionResult> Index(UserEditProfile p)
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);//güncelleme için
            if(p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                //resim ismi benzersiz olmalı
                var imageName = Guid.NewGuid()+extension;
                //Guid hexa decimal benzersiz isim kodu üretmece
                var savelocation = resource + "/wwwroot/UserImages/" + imageName;
                //nereye kaydedileceği tanımlandı 
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageURL = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.Phonenumber;
            user.Email = p.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login"); //login e dönmeli çünkü şifre mifre değişti
            }
            return View();
        }

    }
}
