using Microsoft.AspNetCore.Identity;

namespace TaskManager.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
