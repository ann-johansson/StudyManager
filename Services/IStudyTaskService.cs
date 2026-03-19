using StudyManager.DTOs;
using StudyManager.Models;

namespace StudyManager.Services
{
    public interface IStudyTaskService
    {
        // Här skriver vi bara "rubrikerna" (vad köket ska kunna göra)
        Task<IEnumerable<StudyTask>> GetAllTasksAsync();
        Task<StudyTask> AddTaskAsync(TaskCreateDto dto);
    }
}
