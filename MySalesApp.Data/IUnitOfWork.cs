using System;

namespace MySalesApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void Rollback();

        void SaveChanges();
    }
}