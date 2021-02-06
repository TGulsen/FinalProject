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
            ProductManager productManager = new ProductManager(new EfProductdal());


            Console.WriteLine("-----------");

            foreach (var product in productManager.GetByUnitPrice(0, 50))
            {
                
                Console.WriteLine(product.ProductName);
            }
            
        }
    }
}
