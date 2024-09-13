using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAnnouncementDal : IGenericDal<Announcement>
    {
        void AnnouncementStatusToTrue(int id);
        void AnnouncementStatusToFalse(int id);

        /*Bu yazılan iki metot özel metotturlar. GenericDal'da bulunmazlar sadece Announccement 
        entitysine özel yazıldılar. Burada entity frameworkda yapacağımız işlemin imzasını attık.
        Announcementa ait olan Status propertiesi id değerini alarak Ture veya False olarak  
        kullanıcı tarafından değiştirilecektir.
        Buradan sonra EfAnnouncementDal classına gidilir.*/

    }
}
