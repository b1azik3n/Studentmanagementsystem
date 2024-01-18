using Microsoft.EntityFrameworkCore;
using Studentmanagementsystem.Models.Domain;

namespace Studentmanagementsystem.Data
{
    public class DbStudentContext : DbContext
    {
        public DbStudentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}


  
