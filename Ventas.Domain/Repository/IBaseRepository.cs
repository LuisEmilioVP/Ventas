using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ventas.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Save(TEntity[] entities);

        void Update(TEntity entity);
        void Update(TEntity[] entities);

        void Remove(TEntity entity);
        void Remove(TEntity[] entities);

        TEntity GetEntity(int entityid);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetEntities();

        void SaveChanges();
    }
}