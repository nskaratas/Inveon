using Inveon.ECommerce.Business.Abstract;
using Inveon.ECommerce.Entities;
using Inveon.ECommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Inveon.ECommerce.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
       

        public HomeController(IProductService productService)
        {
            this.productService = productService;
          
        }

        public IActionResult Index()
        {
            List<Product>  products = productService.GetAll();
          
            return View(products);
        }
        


    }
}
