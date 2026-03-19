using Microsoft.EntityFrameworkCore;
using StudyManager.Models;

namespace StudyManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StudyTask> StudyTasks { get; set; }
    }
}
