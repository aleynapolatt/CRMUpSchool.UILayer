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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        //dependency injection olayı
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category t)
        {
            _categoryDal.delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);

        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            /*
            if(t.CategoryName!=null && t.CategoryName.Length>=5 && t.CategoryDescription.StartsWith("A"))
            {
                _categoryDal.insert(t);
            }
            else
            {
                //error message
            }
            */
            _categoryDal.insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.update(t);
        }
    }
}
