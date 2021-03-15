using Inveon.ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace Inveon.ECommerce.WebApp.Models
{
    public class ProductModel:Product
    { 
        public List<IFormFile> Files { get; set; }
        public string Cover { get; set; }
      
    }
}
