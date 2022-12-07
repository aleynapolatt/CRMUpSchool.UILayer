using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.Concrete
{
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        private readonly IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }

        public List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public void TDelete(IEmployeeTaskDetailDal t)
        {
            throw new NotImplementedException();
        }

        public IEmployeeTaskDetailDal TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<IEmployeeTaskDetailDal> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(IEmployeeTaskDetailDal t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(IEmployeeTaskDetailDal t)
        {
            throw new NotImplementedException();
        }
    }
}
