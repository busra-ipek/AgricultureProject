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
    public class ContactManager : IContactService
    {
		//Bir adet yapıcı-constructor metot tanımlanır. Bu metot bulunduğu classın ismiyle aynı olmalıdır.
		//Bu class IContactService interfacini miras alır, fakat bu interfacein içi boş olmasına rağmen yine de metotlar implemente edilmiştir. 

		private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> GetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void Insert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
