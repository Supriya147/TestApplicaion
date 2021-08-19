using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace TestApplication.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SUPRIYALAC-LAP\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");


            modelBuilder.Entity<EmployeeDetails>(
build => { build.HasKey(t => new { t.Id }); });
            modelBuilder.Entity<Employee>(
build => { build.HasKey(t => new { t.Id }); });


        }


    }
}
