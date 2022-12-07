using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email Adress")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Phonenumber")]
        public string Phonenumber { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        public string Password{ get; set; }


        [Required(ErrorMessage = "Please Enter Your Password Again")]
        [Compare("Password", ErrorMessage ="Try Again")]
        public string ConfirmPassword { get; set; }

    }
}
