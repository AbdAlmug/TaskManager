using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext : IdentityDbContext<Users>
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAssignment> TasksAssignments { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().Property(t => t.Priority).HasConversion<string>();
            modelBuilder.Entity<Tasks>().Property(t => t.Status).HasConversion<string>();





            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);KD


        }
    }
}
