using MySalesApp.Data.Entities;
using System.Collections.Generic;

namespace MySalesApp.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void Create(TEntity entity);

        void Delete(int id);

        List<TEntity> GetAll();

        PagedResult<TEntity> GetAll(int pageNumber, int pageSize);

        TEntity GetById(int id);

        void Update(TEntity entity);
    }
}