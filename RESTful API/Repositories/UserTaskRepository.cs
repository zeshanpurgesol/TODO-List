using Microsoft.EntityFrameworkCore;
using RESTful_API.Models;
using System;

namespace RESTful_API.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _context;

        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTask>> GetUserTasks()
        {
            return await _context.UserTasks.ToListAsync();
        }

        public async Task<IEnumerable<UserTask>> GetTasksByUserId(int userId)
        {
            return await _context.UserTasks.Where(task => task.UserId == userId).ToListAsync();
        }

        public async Task<UserTask> GetTaskById(int id)
        {
            return await _context.UserTasks.FindAsync(id);
        }

        public async Task AddTask(UserTask userTask)
        {
            await _context.UserTasks.AddAsync(userTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(UserTask userTask)
        {
            _context.Entry(userTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var userTask = await _context.UserTasks.FirstOrDefaultAsync(x=>x.Id==id);
            _context.UserTasks.Remove(userTask);
            await _context.SaveChangesAsync();
        }
    }
}
