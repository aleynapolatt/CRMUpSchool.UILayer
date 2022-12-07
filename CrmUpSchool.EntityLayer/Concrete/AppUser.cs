using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.Concrete
{
    //approle -- normalizedname e karşılık (aspnet.roles) user ise aspnetusers a karşılık 
    //<> arasına gelen tür artan değer olarak görmek istediğimizden int
   public class AppUser:IdentityUser<int>
    {
        // işin ilginç tarafı AppUser kısmında UserName olmamasına rağmen save etmede sıkıntı yaşadık. 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public List<EmployeeTask> EmployeeTasks { get; set; }
        //mappleme işlemiyle de yapılabiliyor bu 
    }
}
