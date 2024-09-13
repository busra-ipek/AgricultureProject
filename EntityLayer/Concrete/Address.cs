using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{

    public class Address
    {
        public int AddressID { get; set; }
        public  string? AddressName { get; set; }
        public  string? City { get; set; }
        public  string? PhoneNumber { get; set; }
        public  string? Mail { get; set; }
        public  string? MapInfo { get; set; }
    }
}
