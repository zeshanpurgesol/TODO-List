using Microsoft.AspNetCore.Mvc;
using RESTful_API.Models;
using RESTful_API.Services;

namespace RESTful_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTasks()
        {
            var tasks = await _userTaskService.GetUserTasks();
            return Ok(tasks);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTasksByUserId(int userId)
        {
            var tasks = await _userTaskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetTaskById(int id)
        {
            var task = await _userTaskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(UserTask task)
        {
            await _userTaskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, UserTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            await _userTaskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _userTaskService.DeleteTask(id);
            return NoContent();
        }
    }
}
