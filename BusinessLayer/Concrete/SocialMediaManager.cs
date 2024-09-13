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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialmediaDal;

        public SocialMediaManager(ISocialMediaDal socialmediaDal)
        {
            _socialmediaDal = socialmediaDal;
        }

        public void Delete(SocialMedia t)
        {
            _socialmediaDal.Delete(t);
        }

        public SocialMedia GetById(int id)
        {
            return _socialmediaDal.GetById(id);
        }

        public List<SocialMedia> GetListAll()
        {
            return _socialmediaDal.GetListAll();
        }

        public void Insert(SocialMedia t)
        {
            _socialmediaDal.Insert(t);
        }

        public void Update(SocialMedia t)
        {
            _socialmediaDal.Update(t);
        }
    }
}
