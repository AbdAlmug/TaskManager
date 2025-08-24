using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "SubTask Name is required.")]
        [DisplayName("SubTask Name")]
        public required string SubTaskName { get; set; }
        public bool Completed { get; set; } = false;
        public int TaskId { get; set; } // Foreign key to Tasks
        public Tasks Task { get; set; } = null!;// Navigation property to Tasks
    }
}