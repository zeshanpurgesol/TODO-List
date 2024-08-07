using RESTful_G_Repo.Models;
using RESTful_G_Repo.Repo;

namespace RESTful_G_Repo.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IGenericRepository<UserTask> _userTaskRepository;

        public UserTaskService(IGenericRepository<UserTask> userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            return await _userTaskRepository.GetAllAsync();
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync(int page, int pageSize)
        {
            return await _userTaskRepository.GetAllAsync(page, pageSize);
        }

        public async Task<UserTask> GetTaskByIdAsync(int id)
        {
            return await _userTaskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserTask>> GetTasksByUserIdAsync(int userId)
        {
            var list = await _userTaskRepository.GetAllAsync();
            return list.Where(x=>x.Id == userId); 

        }

        public async Task AddTaskAsync(UserTask userTask)
        {
            await _userTaskRepository.AddAsync(userTask);
        }

        public async Task AddTasksAsync(IEnumerable<UserTask> userTasks)
        {
            await _userTaskRepository.AddRangeAsync(userTasks);
        }

        public async Task UpdateTaskAsync(UserTask userTask)
        {
            await _userTaskRepository.UpdateAsync(userTask);
        }

        public async Task UpdateTasksAsync(IEnumerable<UserTask> userTasks)
        {
            await _userTaskRepository.UpdateRangeAsync(userTasks);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _userTaskRepository.DeleteAsync(id);
        }

        public async Task DeleteTasksAsync(IEnumerable<int> ids)
        {
            await _userTaskRepository.DeleteRangeAsync(ids);
        }
    }
}
