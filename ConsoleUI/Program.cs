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
            Console.WriteLine("Hello World!");
            //abstractların içine referans
            //tutucular konulur
            //Concretelerin içine ise asıl görevi yapanlar
            //abstract'lar ile uygulamalar arasındaki bağlantılar
            //minimize edilir
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            //SOLİD O harfi--> open closed principle
            //projeye yeni bir şey eklendiğinde öncekiler etkilenmez

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName);
            }



        }
    }
}
