using System.ComponentModel.DataAnnotations;

namespace StudyManager.DTOs
{
    public class TaskCreateDTO
    {
        [Required(ErrorMessage = "The task must have a title!")]
        [MaxLength(100, ErrorMessage = "The title can't be more than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "It must have a subject.")]
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime? Deadline { get; set; }
    }
}
