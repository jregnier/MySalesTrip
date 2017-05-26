using LiteDB;
using MySalesApp.Data.Entities;
using MySalesApp.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MySalesApp.Data.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly string _collectionName;
        private readonly LiteDatabase _db;

        public Repository(LiteDatabase db, string collectionName)
        {
            _db = db;
            _collectionName = collectionName;
        }

        protected string CollectionName
        {
            get
            {
                return _collectionName;
            }
        }

        protected LiteDatabase LiteDatabase
        {
            get
            {
                return _db;
            }
        }

        public void Create(TEntity entity)
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);
            customers.Insert(entity);
        }

        public void Delete(int id)
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);
            customers.Delete(id);
        }

        public List<TEntity> GetAll()
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);
            return customers.FindAll().ToList();
        }

        public PagedResult<TEntity> GetAll(int pageNumber, int pageSize)
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);

            var result = customers
                    .Find(Query.All(), pageNumber * pageSize, pageSize)
                    .ToList();

            return new PagedResult<TEntity>(result, result.Count);
        }

        public TEntity GetById(int id)
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);
            return customers.FindById(id);
        }

        public void Update(TEntity entity)
        {
            var customers = _db.GetCollection<TEntity>(_collectionName);
            customers.Update(entity);
        }
    }
}