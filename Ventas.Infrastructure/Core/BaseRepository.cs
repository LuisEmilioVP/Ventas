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

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Add(TEntity[] entities)
        {
            this.entities.AddRange(entities);
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public TEntity GetEntity(int entityid)
        {
            return this.entities.Find();
        }

        public void Remove(TEntity entity)
        {
           this.entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.entities.RemoveRange(entities);
        }
    }
}
