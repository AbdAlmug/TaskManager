using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.DataAccess.Repository.IRepository
{
    public interface ITasksRepository : IRepository<Tasks>
    {
        void Update(Tasks obj);
    
    }
}
