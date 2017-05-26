using LiteDB;
using System;

namespace MySalesApp.Data.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LiteDatabase _db;
        private LiteTransaction _transaction;

        public UnitOfWork(LiteDatabase db)
        {
            _db = db;
        }

        public LiteDatabase Db { get => _db; }

        public void BeginTransaction()
        {
            _transaction = _db.BeginTrans();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("UnitOfWork has already been saved.");
            }

            _transaction.Commit();
            _transaction = null;
        }
    }
}