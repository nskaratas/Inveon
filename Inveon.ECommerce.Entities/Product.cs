using Inveon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inveon.ECommerce.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Image { get; set; }
    }
}
