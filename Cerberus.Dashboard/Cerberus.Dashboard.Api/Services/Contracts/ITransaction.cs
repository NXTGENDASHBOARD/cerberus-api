using System;

namespace Cerberus.Dashboard.Api.Services.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
