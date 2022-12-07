using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
    class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public void GetProductByCategory()
        {
            throw new NotImplementedException();
        }

    }

 
}
