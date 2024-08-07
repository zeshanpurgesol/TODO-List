using Microsoft.EntityFrameworkCore;
using RESTful_G_Repo.Models;
using System.Collections.Generic;

namespace RESTful_G_Repo.Repo
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}
