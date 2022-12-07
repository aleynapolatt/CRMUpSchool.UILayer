using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> 
    //T opsiyoneldir farklı parametre de alınabilir
    {
        void insert(T t);
        void update(T t);
        void delete(T t);
        //delete işleminin olması için illa delete ismi olması gerekmez
        List<T> GetList();
        T GetById(int id);
    }
}
