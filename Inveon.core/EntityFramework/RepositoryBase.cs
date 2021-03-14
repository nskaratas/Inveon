using Inveon.core.Dal;
using Inveon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.core.EntityFramework
{
    public class RepositoryBase<Tentity, Tcontext> : IRepository<Tentity>
          where Tentity : class, IEntity
          where Tcontext : DbContext
    {

        protected readonly Tcontext context;

        public RepositoryBase(Tcontext context)
        {
            this.context = context;
        }

        public void Add(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
            Save();
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity); 
            Save();
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }

        public Tentity GetById(int Id)
        {
            return context.Set<Tentity>().Find(Id);
        }

        public IQueryable<Tentity> GetEx(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
            Save();
        }
    }
}
