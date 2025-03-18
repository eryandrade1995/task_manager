using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Interfaces;

namespace TaskManager.Infrastructure.Persistence.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly TaskManagerDBContext _context;

        public BaseRepository(TaskManagerDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete<T>(T model) where T : class
        {
            var entry = _context.Entry(model);

            if (entry.State == EntityState.Detached)
                _context.Attach(model);


            _context.Remove(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _context.DisposeAsync();
                return false;
            }
            return true;
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task Save<T>(T model) where T : class
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> Update<T>(T model) where T : class
        {
            _context.Update(model);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}