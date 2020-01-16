using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InventoryService.Models.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class
    {
        void Create(T model);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
        void Edit(T model);
        void Delete(T model);


    }
}
