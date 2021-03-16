using Inveon.ECommerce.Business.Abstract;
using Inveon.ECommerce.Business.DTOs;
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
        private readonly IProductImageService productImageService;


        public HomeController(IProductService productService, IProductImageService productImageService)
        {
            this.productService = productService;
            this.productImageService = productImageService;

        }

        public IActionResult Index()
        {
            List<ProductDto> products = productService.GetAll();
            return View(products);
        }
        


    }
}
