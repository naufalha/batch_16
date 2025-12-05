using Microsoft.EntityFrameworkCore;
using SmkNgawi.Entities;
namespace SmkNgawi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Major> Majors {get; set;}
        public DbSet<ClassRoom> ClassRooms {get; set;}
        public DbSet<Student> Students {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     
        {
            optionsBuilder.UseSqlite("data Source=smkngawi_v2.db");
        }
    }

}