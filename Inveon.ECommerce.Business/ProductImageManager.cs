using Inveon.ECommerce.Business.Abstract;
using Inveon.ECommerce.DataAccess.Abstract;
using Inveon.ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text; 

namespace Inveon.ECommerce.Business
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageRepository repo; 
        public ProductImageManager(IProductImageRepository repo)
        {
            this.repo = repo;
        }

        public void Add(ProductImage entity)
        {
            repo.Add(entity);
        }

        public void Delete(ProductImage entity)
        {
            repo.Delete(entity);
        }

        public List<ProductImage> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public ProductImage GetById(int Id)
        {
            return repo.GetById(Id);
        }

        public List<ProductImage> GetEx(Expression<Func<ProductImage, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }

        public void Update(ProductImage entity)
        {
            repo.Update(entity);
        }
        public string Cover(int productId)
        {
            var random = repo.GetEx(x => x.ProductId == productId).FirstOrDefault();
            if (random == null)
            {
                return "no-photo.jpg";
            }
            return "Uploads/"+random.FileName;

        }
        public List<ProductImage> ProductImages(int productId)
        {
            return repo.GetEx(x => x.ProductId == productId).ToList();
        }
        public void UploadImages(List<IFormFile> images,int  productId)
        {
            foreach(var item in images)
            {
                string uniquefilename = null;
                string uploadsfolder = Path.Combine("wwwroot/uploads");
                uniquefilename = Guid.NewGuid().ToString() + "_" + item.FileName;
                string filepath = Path.Combine(uploadsfolder, uniquefilename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                   item.CopyTo(filestream);
                    ProductImage image = new ProductImage
                    {
                        FileName = uniquefilename,
                        ProductId = productId
                    };
                    Add(image);
                }
            }

        }
    }
}
