using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Models
{
    public class DepartmentSalary
    {
        public string departmentname { get; set; }
        public int salaryavg { get; set; }
        public int SalaryAvg { get; internal set; }
    }
}
