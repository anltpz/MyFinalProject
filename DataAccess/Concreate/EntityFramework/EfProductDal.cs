using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                var addedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var deletedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return filter == null
                   ?context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();
                    // arkada tarafta bize select * from products döndürüyor


            }
        }

        public void Update(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var updatedEntity = context.Entry(entity);// veri kaynagıyla ilişkilendirildi;
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
