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
    public class ProductManager : IProductService
    {
        IProductRepository repo;

        public ProductManager(IProductRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Product entity)
        {
            repo.Add(entity);
        }

        public void Delete(Product entity)
        {
            repo.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Product GetById(int Id)
        {
            return repo.GetById(Id);
        }

        public List<Product> GetEx(Expression<Func<Product, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(Product entity)
        {
            repo.Update(entity);
        }
    }
}
