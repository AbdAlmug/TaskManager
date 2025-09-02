using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Data;
using TaskManager.DataAccess.Repository.IRepository;
using TaskManager.Models;

namespace TaskManager.DataAccess.Repository
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {
        private readonly TaskManagerDbContext _db;  
        public TasksRepository(TaskManagerDbContext db) : base(db)
        {
            _db = db;
        }
      
        public void Update(Tasks obj)
        {
            _db.Tasks.Update(obj);
        }
    }
}
