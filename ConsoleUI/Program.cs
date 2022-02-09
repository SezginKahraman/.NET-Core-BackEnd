using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //abstractların içine referans
            //tutucular konulur
            //Concretelerin içine ise asıl görevi yapanlar
            //abstract'lar ile uygulamalar arasındaki bağlantılar
            //minimize edilir
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }



        }
    }
}
