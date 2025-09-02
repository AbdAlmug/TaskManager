using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITasksRepository Tasks { get; }
        void Save();
    }
}
