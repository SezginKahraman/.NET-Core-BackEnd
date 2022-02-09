using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        //productla ilgili veritabınında
        //yapılacak olan operasyonları
        //içeren interface !
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        //interface methodları default
        //olarak publictir
        List<Product> GetAllByCategory(int categoryId);

    }
}
