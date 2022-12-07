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
   public class EmployeeTaskManager:IEmployeeTaskService
    {
        IEmployeeTaskDal _employeeTaskDal;
        
        public EmployeeTaskManager(IEmployeeTaskDal employeeTaskDal)
        {
            _employeeTaskDal = employeeTaskDal;
        }

        public void TDelete(EmployeeTask t)
        {
            throw new NotImplementedException();
        }

        public EmployeeTask TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeTask> TGetEmployeeTaskByEmployee()
        {
            return _employeeTaskDal.GetEmployeeTaskByEmployee();
        }

        public List<EmployeeTask> TGetEmployeeTaskById(int id)
        {
            return _employeeTaskDal.GetEmployeeTaskById(id);       
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDal.GetList();
            //include methodunda ilk yapılması gereken
            //employee methodunda özelleştirme
            //data kısmında abstract içinde tanımlamalıyız
            //sonra git ef yi ekle 
            //task service list olarak attık

        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDal.insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            throw new NotImplementedException();
        }
    }
}
