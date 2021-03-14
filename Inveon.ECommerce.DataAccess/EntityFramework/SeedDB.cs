using Inveon.ECommerce.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inveon.ECommerce.DataAccess.EntityFramework
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ECommerceDBContext>();

            User admin = new User
            {
                Name = "Inveon Admin",
                Username = "inveon",
                Password = "inveon",
                IsAdmin = true
            };
            if (!context.Users.Any())
            {
                context.Add(admin);
                context.SaveChanges();
            }

            Product product = new Product
            {
                Name = "Sample Product",
                Description = "Sampe Product Description",
                Barcode = "8699567900094",
                Price = 144.87m,
                Quantity=1100
            };
            if (!context.Products.Any())
            {
                context.Add(product);
                context.SaveChanges();
            }
        }
    }
}
