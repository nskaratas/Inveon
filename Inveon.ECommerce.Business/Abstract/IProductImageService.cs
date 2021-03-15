using Inveon.ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Inveon.ECommerce.Business.Abstract
{
   public interface IProductImageService
    {
        List<ProductImage> GetAll();
        List<ProductImage> GetEx(Expression<Func<ProductImage, bool>> predicate);
        ProductImage GetById(int Id);
        string Cover(int productId); 
        List<ProductImage> ProductImages(int productId);
        void Add(ProductImage entity);
        void Update(ProductImage entity);
        void Delete(ProductImage entity);
        void UploadImages(List<IFormFile> files,int productId);
    }
}
