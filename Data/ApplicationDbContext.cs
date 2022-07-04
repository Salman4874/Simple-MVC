using Microsoft.EntityFrameworkCore;
using SchoolPortal.Models;

namespace SchoolPortal.Date
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base( options )
        {

        }

        public DbSet<Student> Student_Data { get; set; }
        public DbSet<Teacher> Teacher_Data { get; set; }
    }
}
