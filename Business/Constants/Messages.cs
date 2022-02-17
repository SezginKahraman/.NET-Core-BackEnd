using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün Eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductListed = "ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bu kategoriye 10'dan fazla ürün koymuşsunuz";

        public static string ProductNameAlreadyExists = "Product Name Already Exists";
        public static string CategoryLimitExceded = "Kategori limiti aşıldı";
    }
}
