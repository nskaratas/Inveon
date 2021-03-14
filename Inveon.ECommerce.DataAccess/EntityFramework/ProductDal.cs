using Inveon.core.EntityFramework;
using Inveon.ECommerce.DataAccess.Abstract;
using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.DataAccess.EntityFramework
{
    public class ProductDal : RepositoryBase<Product, ECommerceDBContext>, IProductRepository
    {
        public ProductDal(ECommerceDBContext context) : base(context)
        {
        }
    }
}
