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
    public class AgricultureContext :IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ARDACIMEN\\SQLEXPRESS;database=DbAgriculture;integrated security=true");
        }

        public DbSet<Adress> Adresses { get; set; }

        public DbSet<Contact>  Contacts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Service> Services { get; set; }    

        public DbSet<Team> Teams { get; set; }

		public DbSet<SocialMedia> SocialMedias { get; set; }

		public DbSet<AboutUs> aboutUs { get; set; }

		public DbSet<Admin> admins { get; set; }






	}
}
