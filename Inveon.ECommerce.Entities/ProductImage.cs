using Inveon.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inveon.ECommerce.Entities
{
    public class ProductImage:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
