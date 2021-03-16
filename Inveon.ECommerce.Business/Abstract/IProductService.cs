using Inveon.ECommerce.Business.DTOs;
using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.ECommerce.Business.Abstract
{
   public interface IProductService
    {
        List<ProductDto> GetAll();
        List<Product> GetEx(Expression<Func<Product, bool>> predicate);
        Product GetById(int Id);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity); 
    }
}
