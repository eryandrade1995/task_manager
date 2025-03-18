using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        private readonly TaskManagerDBContext _context;

        public TaskRepository(TaskManagerDBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TaskItem>> GetAll() => await _context.Tasks.ToListAsync();

        public async Task<TaskItem> Get(string code) => await _context.Tasks.FindAsync(code);


    }
}