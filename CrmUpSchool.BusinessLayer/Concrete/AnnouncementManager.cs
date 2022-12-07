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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;
        
        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public List<Announcement> TContainA()
        {
           return _announcementDal.ContainA();
        }

        //ent dapper a geçmek istediğinde her yeri değiştrmek zorunda kalmaz
        public void TDelete(Announcement t)
        {
            _announcementDal.delete(t); //data.accessten geliyor~Ef den geliyor
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);

        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public void TInsert(Announcement t)
        {
            _announcementDal.insert(t);
        }

        public void TUpdate(Announcement t)
        {
            _announcementDal.update(t);
        }
    }
}
