using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager:IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementManager;

        public AnnouncementManager(IAnnouncementDal announcementManager)
        {
            _announcementManager = announcementManager;
        }

        public void AnnouncementStatusToFalse(int id)
        {
          _announcementManager.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _announcementManager.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
                _announcementManager.Delete(t);
        }

        public Announcement GetById(int id)
        {
           return _announcementManager.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
           return _announcementManager.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementManager.Insert(t); 
        }

        public void Update(Announcement t)
        {
            _announcementManager.Update(t);
        }
    }
}
