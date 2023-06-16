using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ventas.Domain.Repository
{
    public interface  IBaseRepository<TEntity> where TEntity : class
    {
        //void para especificar que el método no devuelve un valor. 

        void Add(TEntity entity);
        void Add(TEntity[] entities);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Remove(TEntity entity);
        void Remove(TEntity[] entities);

        TEntity GetEntity(int entityid);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities();
        void SaveChanges();
    }
}
