using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Password should be at least {length} character",
            };
            //return base.PasswordTooShort(length);
        }
        //şifre küçük harf içermeli hatasında 
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code ="PasswordRequiresLower",
                Description=$"Password should have at least one lower character"
            };
          //  return base.PasswordRequiresLower();
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = $"Password should have at least one upper character"
            };
            //  return base.PasswordRequiresLower();
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = $"Password should have at least one digit"
            };
            //  return base.PasswordRequiresLower();
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"You have enter another email addresses"
            };
            //  return base.PasswordRequiresLower();
        }


        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"You have to enter another username, because the name you wanted is taken by another user"
            };
            //  return base.PasswordRequiresLower();
        }

    }
}
