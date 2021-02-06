using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: DB tabloları ile proje Class'larını bağlamaya yarar.
    // EntityFramework içinde DbContext vardır.
    class NorthwindContext:DbContext
    {
        //kullanacağımız veri tabanına söylüyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");


    }
        //Veritabanıdaki hangi nesnenin hangi nesneme bağlı olacağını gösterir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
