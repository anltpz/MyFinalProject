using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            Console.WriteLine("2 numaralı kategorideki ürünler");
            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("************************Min 20 ve 50 fiyat aralıgındaki ürünler");
            foreach (var product in productManager.GetByUnitPrice(20, 50)) 
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
