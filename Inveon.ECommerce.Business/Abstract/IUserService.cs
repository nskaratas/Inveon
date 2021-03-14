using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.ECommerce.Business.Abstract
{
   public interface IUserService
    {
        List<User> GetAll();
        List<User> GetEx(Expression<Func<User, bool>> predicate);
        User GetById(int Id);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
