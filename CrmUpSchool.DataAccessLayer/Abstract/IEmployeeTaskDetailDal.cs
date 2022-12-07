using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
   public interface IEmployeeTaskDetailDal: IGenericDal<EmployeeTaskDetail>
    {
        //entity özel method yazmaca
        List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id);
        //görevin detayları ile id yi buluşturmaca

    }
}
