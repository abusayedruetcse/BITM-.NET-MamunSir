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
                new Product(){Id=5,Name="Window",Price=3500},
                new Product(){Id=6,Name="Bed",Price=2000}
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
        static private void SelectAll(List<Product> products)
        {
            //1.select p
            Console.WriteLine("select p\n\n");
            var selectedProductList = from p in products
                                      where p.Price > 1000 & p.Price < 3000
                                      select p;                                     
            Display(selectedProductList);
            //2.select p.Name
            Console.WriteLine("select p.Name\n\n");
            var selectedProductNameList = from p in products
                                      where p.Price > 1000 & p.Price < 3000
                                      select p.Name;
            foreach (var p in selectedProductNameList)
            {
                Console.WriteLine(" Name: " + p + Environment.NewLine);
            }
            //3.select anonymous obj
            Console.WriteLine("select anonymous obj\n\n");
            var selectedProductAnonymousList = from p in products
                                               where p.Price > 1000 & p.Price < 3000
                                               select new { Name = p.Name, Price = Convert.ToInt32(p.Price) - 50 };
            foreach(var p in selectedProductAnonymousList)
            {
                Console.WriteLine("Name: " + p.Name + " Offered Price: " + p.Price + Environment.NewLine);
            }
            //4.orderby p.Name
            Console.WriteLine("orderby p.Name\n\n");
            var orderbyProductList = from p in products
                                     where p.Price > 0 & p.Price < 5001
                                     orderby p.Name
                                     //orderby p.Name,p.Price
                                     select p;
            Display(orderbyProductList);
            //5.group by p.Name
            Console.WriteLine("group by p.Name\n\n");
            var groupbyNameProductList = from p in products
                                         where p.Price > 0 & p.Price < 5001
                                         group p by p.Name into g
                                         orderby g.Key
                                         select g;
            foreach(var g in groupbyNameProductList)
            {
                Console.WriteLine("Name: " + g.Key);
                foreach(var pg in g)
                {
                    Console.WriteLine("\t\tId: " + pg.Id + " Name: " + pg.Name + " Price: " + pg.Price + Environment.NewLine);
                }
            }
            //  Another way
            Console.WriteLine("Another way\n\n");
            var groupbyNameProductAnonymousList = from p in products
                                                  where p.Price > 0 & p.Price < 5001
                                                  group p by p.Name into g
                                                  select new { key = g.Key, Products = g.ToList() };
            foreach (var g in groupbyNameProductAnonymousList)
            {
                Console.WriteLine("Name: " + g.key);
                foreach (var product in g.Products)
                {
                    Console.WriteLine("\t\tId: " + product.Id + " Name: " + product.Name + " Price: " + product.Price + Environment.NewLine);
                }
            }
        }


    }
}
