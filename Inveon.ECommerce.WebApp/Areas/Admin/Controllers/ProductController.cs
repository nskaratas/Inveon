using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inveon.ECommerce.DataAccess.EntityFramework;
using Inveon.ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Inveon.ECommerce.WebApp.Models;
using System.IO; 
using Inveon.ECommerce.Business.Abstract;

namespace Inveon.ECommerce.WebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService; 
        private readonly IProductImageService productImageService;
      
        public ProductController(IProductService productService, IProductImageService productImageService)
        {
            this.productService = productService; 
            this.productImageService = productImageService; 
        }
        [Route("admin/product")]
        // GET: admin/product/Products
        public IActionResult Index()
        {

            return View(productService.GetAll());
        }
        [Route("admin/product/details/{id}")]
        // GET: admin/product/Products/Details/5
        public IActionResult Details(int id)
        { 
            var product = productService.GetById(id); 
            if (product == null)
            {
                return NotFound();
            }
            product.Images = productImageService.ProductImages(id);
            return View(product);
        }
        [Route("admin/product/create")]
        // GET: admin/product/Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/product/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("admin/product/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Files,Barcode,Price,Quantity")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
            
                productService.Add(product);
                if (product.Files != null)
                {
                    productImageService.UploadImages(product.Files, product.Id);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [Route("admin/product/edit/{id}")]
        // GET: admin/product/Products/Edit/5
        public IActionResult Edit(int id)
        {
            
            var product =  productService.GetById(id); 
            if (product == null)
            {
                return NotFound();
            }
            ProductModel model = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Barcode = product.Barcode,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Files=null
            };
            return View(model);
        }

        // POST: admin/product/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("admin/product/edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Files,Barcode,Price,Quantity")] ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {  
                    productService.Update(product);
                    if (product.Files != null)
                    {
                        productImageService.UploadImages(product.Files, product.Id);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        [Route("admin/product/delete/{id}")]
        // GET: admin/product/Products/Delete/5
        public IActionResult Delete(int id)
        {
            
            var product = productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            } 
            return View(product);
        }

        // POST: admin/product/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("admin/product/delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product =  productService.GetById(id);
            productService.Delete(product); 
            return RedirectToAction(nameof(Index));
        }




        [Route("admin/product/deleteImage/{id}")]
        // GET: admin/product/Products/Delete/5
        public IActionResult DeleteImage(int id)
        {

            var image = productImageService.GetById(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: admin/product/Products/Delete/5
        [HttpPost, ActionName("DeleteImage")]
        [Route("admin/product/deleteImage/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteImageConfirmed(int id)
        {
            var image = productImageService.GetById(id);
            productImageService.Delete(image);
            return RedirectToAction(nameof(Index));
        }




        private bool ProductExists(int id)
        {
            if (productService.GetById(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     }
}
