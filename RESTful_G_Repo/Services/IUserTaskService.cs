using RESTful_G_Repo.Models;

namespace RESTful_G_Repo.Services
{
    public interface IUserTaskService
    {
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
        Task<IEnumerable<UserTask>> GetAllTasksAsync(int page, int pageSize);
        Task<UserTask> GetTaskByIdAsync(int id);
        Task<IEnumerable<UserTask>> GetTasksByUserIdAsync(int userId);
        Task AddTaskAsync(UserTask userTask);
        Task AddTasksAsync(IEnumerable<UserTask> userTasks);
        Task UpdateTaskAsync(UserTask userTask);
        Task UpdateTasksAsync(IEnumerable<UserTask> userTasks);
        Task DeleteTaskAsync(int id);
        Task DeleteTasksAsync(IEnumerable<int> ids);
    }
}
