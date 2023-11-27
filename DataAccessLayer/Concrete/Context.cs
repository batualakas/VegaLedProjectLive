using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;database=VegaLedProjectDb;user=vegaled;password=SuhaErtem.07") ;
        }
        public DbSet<Hizmetlerimiz> Hizmetlerimizs { get; set; }
    }
}
