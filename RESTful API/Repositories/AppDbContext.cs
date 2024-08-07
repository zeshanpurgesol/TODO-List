using Microsoft.EntityFrameworkCore;
using RESTful_API.Models;
using System.Collections.Generic;

namespace RESTful_API.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserTask> UserTasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
