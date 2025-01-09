using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfBaseRepository<TEntity,TContext>:IEntityRepository<TEntity> 
        where TContext: DbContext,IDisposable,new() 
        where TEntity : class, IEntity,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addentity = context.Entry(entity);
                addentity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(int id) {
            using (TContext context = new TContext())
            {
                var entityfind = context.Set<TEntity>().Find(id);

                if (entityfind == null)
                {
                    throw new Exception("silmek istediğiniz varlık bulunamadı.");
                }
                
                context.Entry(entityfind).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addentity = context.Entry(entity);
                addentity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context = new TContext())
            {
                var data = context.Set<TEntity>().SingleOrDefault(filter);
                return data;
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }

        }
    }
}
