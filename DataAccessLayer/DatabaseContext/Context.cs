using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseContext
{
    public class Context : DbContext
    {
        public Context()
        {

        }    
        public DbSet<LoginViewModel> loginViewModel { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<PanelUser> panelUser { get; set; }
        public DbSet<Manager> manager { get; set; }
        public DbSet<SupportForm> supportForm { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AEUI2LS;Database=RannaAppDb;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
