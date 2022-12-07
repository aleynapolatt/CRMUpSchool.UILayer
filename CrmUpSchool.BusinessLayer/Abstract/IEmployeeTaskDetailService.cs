using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.Abstract
{
  public interface IEmployeeTaskDetailService:IGenericService<IEmployeeTaskDetailDal>
    {
        List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id);
    }
}
