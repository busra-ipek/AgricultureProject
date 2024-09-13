using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServiceDal : IGenericDal<Service>
	{
        //IserviceDal, IGenericDal interfaceini miras alır ve IGenericDal<T> ifadesinde
		//T yerine Service sınıfı yazılmış olur, çünkü T bir classtır.
	}
}
