using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineShopManagement.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    public class MEDDbContext : DbContext
    {
        public MEDDbContext()
        {
        }

        //public IConfiguration Configuration; 
        //public StoreDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public MEDDbContext(DbContextOptions<MEDDbContext> options)
            : base(options)
        {
        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<DisplayMedicineInfo> DiplayMedicineInfos { get; set; }
        public DbSet<DisplayMedicine> DisplayMedicines { get; set; }
        public DbSet<MedicineType> MedicineType { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NQ3MDG2\SQLEXPRESS;Database=MedicineShopManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
