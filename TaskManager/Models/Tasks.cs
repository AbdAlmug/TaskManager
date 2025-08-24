using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Tasks
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Task Name is required.")]
        [DisplayName("Task Name")]
        public required string TaskName { get; set; }
        public string? Description { get; set; }
        public DateOnly StartOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required(ErrorMessage = "Due date is required.")]
        [DisplayName("Due On")]
        public required DateOnly DueOn { get; set; }
        [Range(0, 100)]
        public int Progress { get; set; } = 0; // Progress in percentage (0-100)
        public DateOnly ModifiedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? CreatedBy { get; set; } = string.Empty;
        public Priority Priority { get; set; } = Priority.Medium;
        public Status Status { get; set; } = Status.NotStarted;
        public DateOnly CompletionOn { get; set; }
        public string  Notes { get; set; } = string.Empty;
        public bool IsOverdue { get; set; }
        public int PendingDays { get; set; }
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public ICollection<TaskAssignment> TaskAssignments { get; set; } =null!;


    }

    

    public enum Status
    {
        NotStarted, InProgress, Completed
    }
    public enum Priority
    {
        Low, Medium, High
    }

}
