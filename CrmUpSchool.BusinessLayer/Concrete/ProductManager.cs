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
    public class ProductManager : IProductService
    {
        IProductDal productDal;

        // this ve _ fark etmiyor.
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void TDelete(Product t)
        {
            productDal.delete(t);
        }

        public Product TGetById(int id)
        {
            return productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return productDal.GetList();
        }

        public void TInsert(Product t)
        {
            productDal.insert(t);
        }

        public void TUpdate(Product t)
        {
            productDal.update(t);
        }
    }
}
