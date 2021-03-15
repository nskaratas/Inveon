using Inveon.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inveon.ECommerce.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(16)]
        public string Barcode { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
