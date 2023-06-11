using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return this.entities.ToList();
        }

        public TEntity GetEntity(int entityId)
        {
            return this.entities.Find(entityId);
        }

        public void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Save(TEntity entity)
        {
            this.entities.Add(entity);
            this.ventas.SaveChanges();
        }

        public void Save(TEntity[] entities)
        {
            this.entities.AddRange(entities);
            this.ventas.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this.entities.Update(entity);
            this.ventas.SaveChanges();
        }
    }
}
