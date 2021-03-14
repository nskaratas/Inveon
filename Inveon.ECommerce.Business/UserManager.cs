using Inveon.ECommerce.Business.Abstract;
using Inveon.ECommerce.DataAccess.Abstract;
using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.ECommerce.Business
{
    public class UserManager : IUserService
    {
        IUserRepository repo; 
        public UserManager(IUserRepository repo)
        {
            this.repo = repo;
        }
        public void Add(User entity)
        {
            repo.Add(entity);
        }

        public void Delete(User entity)
        {
            repo.Delete(entity);
        }

        public List<User> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public User GetById(int Id)
        {
            return repo.GetById(Id);
        }

        public List<User> GetEx(Expression<Func<User, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(User entity)
        {
            repo.Update(entity);
        }
    }
}
