using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            GetProductsByUnitPrice();

            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryId +". Category: "+category.CategoryName );
            //}

            // Console.WriteLine(categoryManager.GetById(1).CategoryName);
        }

        private static void GetProductsByUnitPrice()
        {
            ProductManager productManager = new ProductManager(new EfProductdal());


            Console.WriteLine("---------------");


            List<string> Category_Name = new List<string>();

            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " ürünü: " + product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}

