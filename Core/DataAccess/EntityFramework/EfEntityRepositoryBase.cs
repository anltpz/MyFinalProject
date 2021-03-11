using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{

    //Entityframework için evrensel kod classıdır
   public  class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
       where TEntity:class , IEntity, new()
       where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                   ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
                // arkada tarafta bize select * from TEntitys döndürüyor


            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }

    }
}
