using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.DataAccessLayer.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        //IAnnouncementDal tekken neden implement gerekiyor da Genericle olunca gerekmiyor
        //Genericrepositoryde çünkü dal var 
        //Genericrepository kısmındaki içindeki sınıf başka şey gelmesi için metot değişmeli 
        public List<Announcement> ContainA()
        {
         

                using (var context = new Context())
                {
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;
                }

           
        }
    }
}
