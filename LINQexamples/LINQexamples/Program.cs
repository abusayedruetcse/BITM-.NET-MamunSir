using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexamples
{
    class Program
    {        
        static void Main(string[] args)
        {
            var products = new List<Product>()
            {
                new Product(){Id=1,Name="Chair",Price=500},
                new Product(){Id=2,Name="Table",Price=1500},
                new Product(){Id=3,Name="Bed",Price=2500},
                new Product(){Id=4,Name="Door",Price=5000},
                new Product(){Id=5,Name="Window",Price=3500}
            };
            //Display(products);
            SelectAll(products);
            Console.ReadKey();
        }
        static private void Display(dynamic products)
        {
            foreach (var product in products)
            {
                Console.WriteLine("Id: " + product.Id + " Name: " + product.Name + " Price: " + product.Price + Environment.NewLine);
            }
        }
        static private void SelectAll(object products)
        {
            var selectedProductList = from p in (List<Product>)products
                                      where p.Price > 1000 & p.Price < 3000
                                      select p;
            Display(selectedProductList);
        }

    }
}
