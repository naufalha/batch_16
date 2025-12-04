using Microsoft.EntityFrameworkCore;
using EmployeeApi.Models;


namespace EmployeeApi.Models
{
    // Inherits from DbContext as per EF Core architecture
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // This DbSet represents the "Employees" table in your SQLite database
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments {get; set;}
    }
}