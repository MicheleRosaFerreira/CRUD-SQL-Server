
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;

namespace ApiCadastros.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModels> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Connection");
                
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModels>(e =>
            {
                e.ToTable("REGISTRATION_OF_EMPLOYEES");
                modelBuilder.Entity<EmployeeModels>().Property(n => n.Nome).IsRequired();
                modelBuilder.Entity<EmployeeModels>().HasKey(i => i.Id);
               

            });

        }
    }
}
