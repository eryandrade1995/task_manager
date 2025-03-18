using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Core.Interfaces
{
    public interface IBaseRepository : IDisposable
    {
        Task Save<T>(T model) where T : class;

        Task<bool> Update<T>(T model) where T : class;

        Task<bool> Delete<T>(T model) where T : class;
    }
}