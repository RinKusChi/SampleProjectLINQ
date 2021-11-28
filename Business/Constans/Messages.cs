using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductNotAdded = "Ürün eklenemedi";
        public static string ProductCountOfCategoryError = "Kategoriye ürün ekleme sınırı aşıldı";
        public static string ProductNameAlreadyExists = "Bu isimle ürün daha önce eklenmiş!";
        public static string CategoryLimitExceded = " Kategori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
