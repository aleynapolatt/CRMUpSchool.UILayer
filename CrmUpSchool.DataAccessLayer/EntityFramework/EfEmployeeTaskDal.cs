using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
    public class EfEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AppUser).ToList();
                return values;

            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
            using(var context=new Context())
            { 
                var values = context.EmployeeTasks.Where(x => x.AppUserID == id).ToList();
                return values;
            }
        }
    }
}
