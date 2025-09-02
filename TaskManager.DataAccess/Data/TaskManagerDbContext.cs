using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;


namespace TaskManager.DataAccess.Data
{
    public class TaskManagerDbContext : IdentityDbContext<Users>
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskAssignment> TasksAssignments { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Status>().HasData(
                new Status { id = 1, Name = "Not Started" },
                new Status { id = 2, Name = "In Progress" },
                new Status { id = 3, Name = "Completed" }
            );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { id = 1, Name = "Low" },
                new Priority { id = 2, Name = "Medium" },
                new Priority { id = 3, Name = "High" }
            );

            modelBuilder.Entity<Tasks>()
                .HasMany(t => t.SubTasks)
                .WithOne(st => st.Tasks)
                .HasForeignKey(st => st.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tasks>()
                .HasMany(t => t.TaskAssignments)
                .WithOne(ta => ta.Tasks)
                .HasForeignKey(ta => ta.TaskId)
                .OnDelete(DeleteBehavior.Cascade);







            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);KD


        }
    }
}
