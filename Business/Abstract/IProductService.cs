using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    // İş katmanındaki servis operasyonlarını yazarız.
    // DataAccess ve Entity ile bağlantılıdır.
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategory(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    };
}
