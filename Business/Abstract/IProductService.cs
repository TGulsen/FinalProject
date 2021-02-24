using Core.Utilities.Results;
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
        //List<Product> GetAll();
        //List<Product>:T
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        
        //void Add(Product product);
        IResult Add(Product product);
        IDataResult<Product> GetById(int ProductId);

    };
}
