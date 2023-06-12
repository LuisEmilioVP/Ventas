using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ventas.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(TEntity[] entities);

        void Update(TEntity entity);
        void Update(TEntity[] entities);

        void Remove(TEntity entity);
        void Remove(TEntity[] entities);

        TEntity GetEntity(int entityid);
        List<TEntity> GetEntities();
        bool Exists(Expression<Func<TEntity, bool>> filter);

        void SaveChanges();
    }
}
