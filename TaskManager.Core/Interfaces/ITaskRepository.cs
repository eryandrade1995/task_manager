using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces
{
    public interface ITaskRepository : IBaseRepository
    {
        Task<IEnumerable<TaskItem>> GetAll();
        Task<TaskItem> Get(string code);
    }
}