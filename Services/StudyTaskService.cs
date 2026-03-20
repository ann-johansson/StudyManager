using Mapster;
using Microsoft.EntityFrameworkCore;
using StudyManager.Data;
using StudyManager.DTOs;
using StudyManager.Models;

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

        public async Task<TaskCreateDTO> AddTaskAsync(TaskCreateDTO dto)
        {
            // Using Mapster to map the DTO to the StudyTask entity
            var newTask = dto.Adapt<StudyTask>();

            newTask.IsCompleted = false;

            _context.StudyTasks.Add(newTask);
            await _context.SaveChangesAsync();

            var finnished = newTask.Adapt<TaskCreateDTO>();

            return finnished;
        }
    }
}
