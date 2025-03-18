using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetAll() => await _taskRepository.GetAll();

        public async Task Delete(string code)
        {
            var item = await _taskRepository.Get(code);

            await _taskRepository.Delete(item);
        }


        public async Task Save(TaskItem item)
        {
            item.Status = "P";
            await _taskRepository.Save(item);
        }

        public async Task Update(TaskItem item) => await _taskRepository.Update(item);
        public async Task<TaskItem> Get(string code) => await _taskRepository.Get(code);

    }
}