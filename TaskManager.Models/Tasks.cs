using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task Name is required.")]
        [DisplayName("Task Title")]
        public required string Title { get; set; }

        public string? Description { get; set; }
        public DateTime StartOn { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Due date is required.")]
        [DisplayName("Due On")]
        public required DateOnly DueOn { get; set; }
        [Range(0, 100)]
        public int Progress { get; set; } = 0; // Progress in percentage (0-100)
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = string.Empty;
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Statuses { get; set; } = null!;
        public int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public Priority Priorities { get; set; } = null!;
        public bool IsCompleted {get; set;} = false;
        public DateTime CompletionOn { get; set; }
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public ICollection<TaskAssignment> TaskAssignments { get; set; } = null!;


    }



    public class Status
    {
        public int id { get; set; }
        public string? Name { get; set; }
       public ICollection<Tasks> Tasks { get; set; } = null!;

    }
    public class Priority
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public ICollection<Tasks> Tasks { get; set; } = null!;
    }

}
