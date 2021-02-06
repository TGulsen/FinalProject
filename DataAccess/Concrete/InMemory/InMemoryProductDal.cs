using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Herhangi bir veritabanından geliyormuş gibi simule ediyoruz.
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitInStock=15,UnitPrice=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitInStock=3,UnitPrice=500},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitInStock = 2,UnitPrice = 1500 },
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitInStock = 65,UnitPrice = 150 },
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitInStock = 1,UnitPrice = 85 }

        };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_product.Remove(product); referans tutulduğu için silinmez!
            // LINQ- Language Integrated Query kullanılır.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)

          // Where parantez içindeki koşulu uyanları yeni bir Liste haline getiriyor.
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        // LINQ- Language Integrated Query
        public void Update(Product product)
        {
            //Gönderdiğim ürün ID'sine sahip olan ürünü bul!
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.UnitPrice = product.UnitPrice;

        }
    }
}
