using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class AgricultureContext : IdentityDbContext<AppUser, AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = LAPTOP-C9AUV0IM; database = DbAgricultureProject;" +
                " integrated security = True; TrustServerCertificate=True");
        }
        /*Migration işlemi yapılırken A connection was successfully established with the server, but then an error occurred
        during the login process. (provider: SSL Provider, error: 0 - Sertifika zinciri güvenilmeyen bir yetkili
        tarafından verildi.)  hatası alındığından dolayı TrustServerCertificate ifadesi eklenmiştir. */

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<About> Abouts { get; set; }

    }
	
}
//Normalde DbContext classını (tabloları veritabanına yansıtır) miras alırdı ama değiştirerek
//IdentityDbContext classından miras alır. Bu yeni class aslında DbContext classını miras alır.

//Appuser ve AppRole ile sql de tablolara yeni sütunlar eklenmiş olur.
