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
using Microsoft.AspNetCore.Hosting;

namespace Inveon.ECommerce.WebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ECommerceDBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(ECommerceDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        [Route("admin/product")]
        // GET: admin/product/Products
        public async Task<IActionResult> Index()
        {

            return View(await _context.Products.ToListAsync());
        }
        [Route("admin/product/details/{id}")]
        // GET: admin/product/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,File,Barcode,Price,Quantity")] ProductModel product)
        {
            if (ModelState.IsValid)
            {

                if (product.File != null)
                {
                    string uniqueFileName = null;
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + product.File.FileName;
                    product.Image = uniqueFileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        product.File.CopyTo(fileStream);
                    }
                }
                _context.Add(product);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [Route("admin/product/edit/{id}")]
        // GET: admin/product/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id); 
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
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity

            };
            return View(model);
        }

        // POST: admin/product/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("admin/product/edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,File,Barcode,Price,Quantity")] ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.File != null)
                    {
                        string uniqueFileName = null;
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + product.File.FileName;
                        product.Image = uniqueFileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            product.File.CopyTo(fileStream);
                        }
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
