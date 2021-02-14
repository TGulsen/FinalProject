using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            GetProductsByUnitPrice();

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

        }

        private static void GetProductsByUnitPrice()
        {
            ProductManager productManager = new ProductManager(new EfProductdal());


            Console.WriteLine("-----------");

            foreach (var product in productManager.GetProductDetails())
            {

                Console.WriteLine(product.CategoryName + " / " +product.ProductName);
            }
        }
    }
}
