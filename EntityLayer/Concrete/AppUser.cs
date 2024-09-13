using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class AppUser : IdentityUser<int>
	{
		public string? NameSurname { get; set; }
		
		//AspNet tablosuna bu propertie sütun olarak eklenir. Ve Id değeri kendi kendine artan olacak şekilde düzenlenir.
	}
}
