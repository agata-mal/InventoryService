using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryService.Models.Repository
{
    public abstract class AbstractRepository <T> where T: class
    {
        public virtual void Create (T model)
        {
            using (var context= new ShopContext())
            {
                context.Set<T>().Add(model);
                context.SaveChanges();
            }
        }
        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context=new ShopContext())
            {
                var query= context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
        public virtual void Edit (T model)
        {
            using (var context = new ShopContext())
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public virtual void Delete (T model)
        {
            using (var context= new ShopContext())
            {
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
       
    }
}