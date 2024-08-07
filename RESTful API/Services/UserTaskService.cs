using RESTful_API.Models;
using RESTful_API.Repositories;

namespace RESTful_API.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<IEnumerable<UserTask>> GetUserTasks()
        {
            return await _userTaskRepository.GetUserTasks();
        }

        public async Task<IEnumerable<UserTask>> GetTasksByUserId(int userId)
        {
            return await _userTaskRepository.GetTasksByUserId(userId);
        }

        public async Task<UserTask> GetTaskById(int id)
        {
            return await _userTaskRepository.GetTaskById(id);
        }

        public async Task AddTask(UserTask userTask)
        {
            await _userTaskRepository.AddTask(userTask);
        }

        public async Task UpdateTask(UserTask userTask)
        {
            await _userTaskRepository.UpdateTask(userTask);
        }

        public async Task DeleteTask(int id)
        {
            await _userTaskRepository.DeleteTask(id);
        }
    }
}
