using Inveon.ECommerce.Business.Abstract;
using Inveon.ECommerce.Business.DTOs;
using Inveon.ECommerce.DataAccess.Abstract;
using Inveon.ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.ECommerce.Business
{
    public class ProductManager : IProductService
    {
        IProductRepository repo;
        IProductImageService imageService;
        public ProductManager(IProductRepository repo, IProductImageService imageService)
        {
            this.repo = repo;
            this.imageService = imageService;
        }

        public void Add(Product entity)
        {
            repo.Add(entity);
        }

        public void Delete(Product entity)
        {
            repo.Delete(entity);
        }

        public List<ProductDto> GetAll()
        {
            return repo.GetAll().Select(x=>new ProductDto { 
                Id=x.Id,
                Name=x.Name,
                Barcode=x.Barcode,
                Description=x.Description,
                Price=x.Price,
                Quantity=x.Quantity,
                Images=imageService.ProductImages(x.Id),
                Cover = imageService.Cover(x.Id),
            }).ToList();
        }

        public Product GetById(int Id)
        {
            return repo.GetById(Id);
        }

        public List<Product> GetEx(Expression<Func<Product, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(Product entity)
        {
            repo.Update(entity);
        }
    }
}
