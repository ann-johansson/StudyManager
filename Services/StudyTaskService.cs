using StudyManager.Data;
using StudyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace StudyManager.Services
{
    public class StudyTaskService : IStudyTaskService
    {
        private readonly ApplicationDbContext _context;

        public StudyTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudyTask>> GetAllAsync(string? search)
        {
            var query = _context.StudyTasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(t => t.Title.Contains(search) || t.Subject.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<StudyTask?> GetByIdAsync(int id)
        {
            return await _context.StudyTasks.FindAsync(id);
        }
    }
}
