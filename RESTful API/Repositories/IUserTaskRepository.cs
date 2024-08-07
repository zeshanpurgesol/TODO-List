﻿using RESTful_API.Models;

namespace RESTful_API.Repositories
{
    public interface IUserTaskRepository
    {
        Task<IEnumerable<UserTask>> GetUserTasks();
        Task<IEnumerable<UserTask>> GetTasksByUserId(int userId);
        Task<UserTask> GetTaskById(int id);
        Task AddTask(UserTask userTask);
        Task UpdateTask(UserTask userTask);
        Task DeleteTask(int id);
    }
}
