using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Web sayfasında bulunan her ayrı alan için concrete klsörü içine classları oluşturuyoruz.
    public class Service
    {
        public int ServiceID { get; set; }
        public string?   Title { get; set; }
        public string? Description { get; set; } //Bu değerler null olabilir bu yüzden ? işareti ekledik.
        public string? Image { get; set; }
        public string? MainClass { get; set; }
        public string? ImageClass { get; set; }
    }
}
