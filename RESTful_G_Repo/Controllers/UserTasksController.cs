using Microsoft.AspNetCore.Mvc;
using RESTful_G_Repo.Models;
using RESTful_G_Repo.Services;

namespace RESTful_G_Repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _userTaskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("GetAllTasksByPage")]
        public async Task<IActionResult> GetAllTasksByPage(int page = 1, int pageSize = 10)
        {
            var tasks = await _userTaskService.GetAllTasksAsync(page, pageSize);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _userTaskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            var tasks = await _userTaskService.GetTasksByUserIdAsync(userId);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(UserTask userTask)
        {
            await _userTaskService.AddTaskAsync(userTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = userTask.Id }, userTask);
        }

        [HttpPost("batch")]
        public async Task<IActionResult> CreateTasks(IEnumerable<UserTask> userTasks)
        {
            await _userTaskService.AddTasksAsync(userTasks);
            return CreatedAtAction(nameof(GetAllTasks), new { }, userTasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UserTask userTask)
        {
            if (id != userTask.Id) return BadRequest();
            await _userTaskService.UpdateTaskAsync(userTask);
            return NoContent();
        }

        [HttpPut("batch")]
        public async Task<IActionResult> UpdateTasks(IEnumerable<UserTask> userTasks)
        {
            await _userTaskService.UpdateTasksAsync(userTasks);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _userTaskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpDelete("batch")]
        public async Task<IActionResult> DeleteTasks([FromQuery] IEnumerable<int> ids)
        {
            await _userTaskService.DeleteTasksAsync(ids);
            return NoContent();
        }
    }
}
