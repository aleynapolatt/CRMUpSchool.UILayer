using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Models
{
    public class UserEditProfile
    {
        public string Name { get; set; }
        //küçük string - büyük sting : Referans yapısı/ Sınıf yapısı 
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
