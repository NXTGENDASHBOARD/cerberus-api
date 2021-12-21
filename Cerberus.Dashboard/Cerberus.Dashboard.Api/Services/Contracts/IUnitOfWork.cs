using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Api.Services.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ITransaction BeginTransaction();
        Task<int> AddAsync<T>(T obj) where T : class;

        Task<int> UpdateAsync<T>(T obj) where T : class;

        Task<int> RemoveAsync<T>(T obj) where T : class;

        Task<IEnumerable<T>> QueryAsync<T>() where T : class;

        void Commit();

        Task CommitAsync();
         
    }
}
