﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementStatusToFalse(int id)
        {
            _announcementDal.AnnouncementStatusToFalse(id);
            //id den gelen değerin Status alanını false'a çevir.
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _announcementDal.AnnouncementStatusToTrue(id);
            //id den gelen değerin Status alanını true'a çevir.
        }

        public void Delete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
            return _announcementDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void Update(Announcement t)
        {
            _announcementDal.Update(t);
        }

        //Özel olarak tanımlanan iki metot burada implemente edilir. Buradan sonra Controllera geçilir.
    }
}
