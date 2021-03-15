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
        private readonly IProductImageService productImageService;


        public HomeController(IProductService productService, IProductImageService productImageService)
        {
            this.productService = productService;
            this.productImageService = productImageService;

        }

        public IActionResult Index()
        {
            List<Product> data = productService.GetAll();
            List<ProductModel> products = new List<ProductModel>();
            foreach (var item in data)
            {
                ProductModel product = new ProductModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Barcode = item.Barcode,
                    Description = item.Description,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Cover = productImageService.Cover(item.Id)

                };
                products.Add(product);
            }
            return View(products);
        }
        


    }
}
