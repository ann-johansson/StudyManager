using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyManager.Services;
using StudyManager.DTOs;
using StudyManager.Models;

namespace StudyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyTaskController : ControllerBase
    {
        private readonly IStudyTaskService _service;

        public StudyTaskController(IStudyTaskService studyTaskService)
        {
            _service = studyTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyTask>>> GetAll([FromQuery] string? search)
        {
            var StudyTasks = await _service.GetAllAsync(search);

            return Ok(StudyTasks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudyTask>> GetById(int id)
        {
            var studyTask = await _service.GetByIdAsync(id);

            if (studyTask == null)
            {
                return NotFound();
            }

            return Ok(studyTask);
        }

        [HttpPost]
        public async Task<ActionResult<TaskCreateDTO>> AddTaskAsyn(TaskCreateDTO createDto)
        {


           var result = await _service.AddTaskAsync(createDto);


            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
