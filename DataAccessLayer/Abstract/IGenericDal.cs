using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class, new()   //Burada T bir entitydir ve T mutlaka bir class olmalıdır.
	{
        void Insert(T t); //T classından türeyen bir t nesnesi 
		void Update(T t);
        void Delete(T t);
        T GetById(int id); //Id ye göre getirir ve bir id parametresi alır.
		List<T> GetListAll();

		//IServiceDal, IAddressDal ve diğer interfaceler bu  generic interface'i miras alırlar.
		//bu şekilde  diğer interfacein içine tekrar tekrar kod yazmaya gerek kalmaz.
	}
}
