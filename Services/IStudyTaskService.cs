using StudyManager.DTOs;
using StudyManager.Models;

namespace StudyManager.Services
{
    public interface IStudyTaskService
    {
        Task<IEnumerable<StudyTask>> GetAllAsync(string? search);

        Task<StudyTask?> GetByIdAsync(int id);
    }
}
