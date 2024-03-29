﻿using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.ValidationRules
{
    public class AnnouncementValidator: AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanını boş geçmeyiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçeriği alanını boş geçmeyiniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girin");
            RuleFor(x => x.Title).MinimumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girin")
        ;
        }
    }

   
}
