using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        //ruleformethodu başlangıçta constructor olmadan neden gelmez

        public EmployeeValidator(){
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Personel Adını Boş Geçmemelisiniz");
            RuleFor(x => x.EmployeeSurname).NotEmpty().WithMessage("Personel Soyadını Boş Geçmemelisiniz");
            RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.EmployeeName).MaximumLength(20).WithMessage("Lütfen 20 karakter fazlası olmasın");


}
    }
}
