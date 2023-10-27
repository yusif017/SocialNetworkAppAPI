using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()   
    {
        public void Add(TEntity entity)
        {
            using TContext context = new();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using TContext context = new();
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
        {
            using TContext context = new();
            return predicate == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
