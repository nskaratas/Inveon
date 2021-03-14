using Inveon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.core.Dal
{
   public interface IRepository<T> where T: class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetEx(Expression<Func<T,bool>> predicate);
        T GetById(int Id);
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}
