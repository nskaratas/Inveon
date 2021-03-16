using Inveon.Core.Entities;
using Inveon.ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.Business.DTOs
{
    public class ProductDto:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<IFormFile> Files { get; set; }
        public string Cover { get; set; }
    }
}
