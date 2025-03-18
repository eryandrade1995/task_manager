using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAll();
        Task Delete(string code);
        Task Update(TaskItem item);
        Task<TaskItem> Get(string code);
        Task Save(TaskItem item);
    }
}