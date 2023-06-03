using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Context;

namespace Ventas.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly VentasContext ventas;

        private readonly DbSet<TEntity> entities;
        public BaseRepository(VentasContext ventas)
        {
            this.ventas = ventas;
            this.entities = this.ventas.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
