using Inveon.ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.DataAccess.EntityFramework
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; } 
    }
}
