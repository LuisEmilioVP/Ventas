﻿using System;
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

        public virtual IEnumerable<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }
        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }
        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);

        }
        public virtual void Remove(TEntity[] entities)
        {
            this.entities.RemoveRange(entities);
        }
        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }
        public virtual void Save(TEntity[] entities)
        {
            this.entities.AddRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
        public virtual void Update(TEntity[] entities)
        {
            this.entities.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.ventas.SaveChanges();
        }
    }
}
