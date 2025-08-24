using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; } // Foreign key to Tasks
        public Tasks Task { get; set; } = null!; // Navigation property to Tasks
        public string AssignmentTo { get; set; } = null!; // Foreign key to ApplicationUser
        [ForeignKey("AssignmentTo")]
        public Users User { get; set; } = null!; // Navigation property to ApplicationUser
        
    }
}