using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //new() lememek için static yapıldı.
        // projede kullanılan sabit mesajlar için oluşturuldu.

        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz!";
        public  static string MaintenanceTime = "Bakım süresince ürünler listenemez!";
        public static string ProductListed = "Ürünler listelendi.";

        public static string UnıtPriceInvalid = "Günlük fiyat geçersiz! ";
    }
}
