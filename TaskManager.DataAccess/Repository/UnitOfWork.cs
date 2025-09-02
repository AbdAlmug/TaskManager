using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Data;
using TaskManager.DataAccess.Repository.IRepository;

namespace TaskManager.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagerDbContext _db;
        public ITasksRepository Tasks { get; private set; }
        public UnitOfWork(TaskManagerDbContext db)
        {
            _db = db;
            Tasks = new TasksRepository(_db);
        }
        public void Save()
        {
             _db.SaveChanges();
        }
    }
}
