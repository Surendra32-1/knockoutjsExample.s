using KnockoutPrastice.Models;
using Microsoft.EntityFrameworkCore;

namespace KnockoutPrastice.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
            
        }
        public DbSet<StudentModel> StudentModels { get; set; }
    }
}
