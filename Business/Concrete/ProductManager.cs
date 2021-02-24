using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
        // iş kodları yazılır.   
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            // Hiç bir sınıf içinde bir sınıf new lenmez. Constructor injection yapılır.
            _productDal = productDal;
        }

         public IResult Add(Product product)
         {
            // ekleme işlemi yapılmadan kontrol edilmesi gereken iş kodları yazılır.
            // magic strings kullanmamak adına Messages sabit olarak kullanılır.

            if (product.ProductName.Length <2 )
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
         }

        public IDataResult<List<Product>> GetAll()
        {
            //akşam 22'de ürünler listesi görüntülenemez.


            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==ProductId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


    }
}
