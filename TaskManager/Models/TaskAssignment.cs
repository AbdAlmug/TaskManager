using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskAssignment
    {
        public int id { get; set; }
        public int TaskId { get; set; } // Foreign key to Tasks
        public Tasks Tasks { get; set; } = null!; // Navigation property to Tasks
        public string AssignmentTo { get; set; } = null!; // Foreign key to ApplicationUser
        [ForeignKey("AssignmentTo")]
        public Users Users { get; set; } = null!; // Navigation property to ApplicationUser
        
    }
}