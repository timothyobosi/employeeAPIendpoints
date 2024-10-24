using Microsoft.EntityFrameworkCore;
using empAI.Models;

namespace empAI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify the table name for the employee entity
            modelBuilder.Entity<Employee>().ToTable("employees");
        }
    }
}