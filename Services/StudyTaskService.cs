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

        public async Task<StudyTask> AddTaskAsync(TaskCreateDTO dto)
        {
            // Using Mapster to map the DTO to the StudyTask entity
            var newTask = dto.Adapt<StudyTask>();

            newTask.IsCompleted = false;

            _context.StudyTasks.Add(newTask);
            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task<StudyTask?> UpdateStatusAsync(int id, bool isCompleted)
        {
            var task = await _context.StudyTasks.FindAsync(id);

            if (task == null)
            {
                return null;
            }

            task.IsCompleted = isCompleted;
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<StudyTask?> UpdateTaskAsync(int id, TaskUpdateDto dto)
        {
            var task = await _context.StudyTasks.FindAsync(id);

            if (task == null) return null;

            dto.Adapt(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.StudyTasks.FindAsync(id);

            if (task == null)
            {
                return false;
            }

            _context.StudyTasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
