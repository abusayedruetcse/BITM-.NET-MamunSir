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
                new Product(){Id=3,Name="Door",Price=2500},
                new Product(){Id=4,Name="Bed",Price=5000},
                new Product(){Id=5,Name="Window",Price=3500},
                new Product(){Id=6,Name="Bed",Price=2000}
            };
            //Display(products);
            //SelectAll(products);
            //UsingWhereMethod(products);
            LINQ101ProjectionSelect(products);
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
                                      where p.Price > 1000 && p.Price < 3000
                                      select p;                                     
            Display(selectedProductList);
            //2.select p.Name
            Console.WriteLine("select p.Name\n\n");
            var selectedProductNameList = from p in products
                                      where p.Price > 1000 && p.Price < 3000
                                      select p.Name;
            foreach (var p in selectedProductNameList)
            {
                Console.WriteLine(" Name: " + p + Environment.NewLine);
            }
            //3.select anonymous obj
            Console.WriteLine("select anonymous obj\n\n");
            var selectedProductAnonymousList = from p in products
                                               where p.Price > 1000 && p.Price < 3000
                                               select new { Name = p.Name, Price = Convert.ToInt32(p.Price) - 50 };
            foreach(var p in selectedProductAnonymousList)
            {
                Console.WriteLine("Name: " + p.Name + " Offered Price: " + p.Price + Environment.NewLine);
            }
            //4.orderby p.Name
            Console.WriteLine("orderby p.Name\n\n");
            var orderbyProductList = from p in products
                                     where p.Price > 0 && p.Price < 5001
                                     orderby p.Name
                                     //orderby p.Name,p.Price
                                     select p;
            Display(orderbyProductList);
            //5.group by p.Name
            Console.WriteLine("group by p.Name\n\n");
            var groupbyNameProductList = from p in products
                                         where p.Price > 0 && p.Price < 5001
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
                                                  where p.Price > 0 && p.Price < 5001
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
        static private void UsingWhereMethod(List<Product> products)
        {
            //using Where method of LINQ with Array or List
            //0. select all
            Console.WriteLine("0. select all\n\n");
            var allProduct = products;
            Display(allProduct);

            //1. select p
            Console.WriteLine("1. select p\n\n");
            var selectedProductList = products
                                            .Where(p => p.Price > 1000 && p.Price < 3000);                                           
            Display(selectedProductList);
            //   Another way 
            Console.WriteLine("1. Another way \n\n");
            var selectedProductAnotherList = products
                                            .Where(p => p.Price > 1000 && p.Price < 3000)
                                            .Select(p => p);
            Display(selectedProductAnotherList);

            //2.select p.Name
            Console.WriteLine("2.select p.Name\n\n");
            var selectedProductNameList = products
                                                .Where(p => p.Price > 1000 && p.Price < 3000)
                                                .Select(p => p.Name);
            foreach (var p in selectedProductNameList)
            {
                Console.WriteLine(" Name: " + p + Environment.NewLine);
            }
            //3.select anonymous obj
            Console.WriteLine("select anonymous obj\n\n");
            var selectedProductAnonymousList = products
                                                    .Where(p => p.Price > 1000 && p.Price < 3000)
                                                    .Select(p=> new { Name = p.Name, Price = Convert.ToInt32(p.Price) - 50 });                                              
            foreach (var p in selectedProductAnonymousList)
            {
                Console.WriteLine("Name: " + p.Name + " Offered Price: " + p.Price + Environment.NewLine);
            }
            //4.orderby p.Name
            Console.WriteLine("4.orderby p.Name\n\n");
            var orderbyProductList = products
                                          .Where(p => p.Price > 0 && p.Price < 5001)
                                          .OrderByDescending(p => p.Name)
                                          .Select(p=>p);                                 
            Display(orderbyProductList);
            //5.group by p.Name
            Console.WriteLine("5.group by p.Name\n\n");
            var groupbyNameProductList = products
                                              .Where(p => p.Price > 0 && p.Price < 5001)
                                              .GroupBy(p => p.Name)
                                              .OrderBy(p => p.Key)
                                              //.Select(p=>p)
                                              ;          
            foreach (var g in groupbyNameProductList)
            {
                Console.WriteLine("Name: " + g.Key);
                foreach (var pg in g)
                {
                    Console.WriteLine("\t\tId: " + pg.Id + " Name: " + pg.Name + " Price: " + pg.Price + Environment.NewLine);
                }
            }
        }     
        static private void LINQ101ProjectionSelect(List<Product> products)
        {
            //1. nested situation for two collections
            Console.WriteLine("1. nested situation for two collections\n\n");
            int[] positions = new int[] { 1, 3, 5 };
            string[] numbers = new string[] { "zero","one", "two", "three", "four", "five", "six" };
            var textNum = from ii in positions
                          select numbers[ii];
            foreach(var num in textNum)
            {
                Console.WriteLine(num + Environment.NewLine);
            }
            //2. Operation on product
            Console.WriteLine("2. Operation on product\n\n");
            var operationOnProductList = from p in products
                                         select new { Upper = p.Name.ToUpper(), Lower = p.Name.ToLower() };
            foreach(var p in operationOnProductList)
            {
                Console.WriteLine("Upper: {0}, Lower: {1}\n", p.Upper, p.Lower);
            }
            //3. Using Index of Collection
            Console.WriteLine("3. Using Index of Collection\n\n");
            var indexedList = products
                                .Select((p,index)=>new {Product=p.Name, Inplace=p.Name.Length==index });  //index for index of list element
            foreach(var p in indexedList)
            {
                Console.WriteLine(p.Product+" Place: "+p.Inplace+Environment.NewLine);
            }
            //4. Compound two from clause
            Console.WriteLine("4. Compound two from clause\n\n");
            var TwoTableCombineList = from index in positions
                                      from p in products
                                      where p.Id == index
                                      select p;
            Display(TwoTableCombineList);
            //5. Combine two relational table
            Console.WriteLine("5. Combine two relational table\n\n");
            var brands = new List<Brand>()
            {
                new Brand(){ Name="ACI",Products=products},
                new Brand(){ Name="Partex",Products=products},
                new Brand(){ Name="RFL",Products=products},
                new Brand(){ Name="Amazon",Products=products}
            };

            var brandsProductsList = from b in brands
                                     from p in b.Products
                                     where p.Price < 1500
                                     select new { Brand = b.Name, Product = p.Name, Price = p.Price };
            foreach(var bp in brandsProductsList)
            {
                Console.WriteLine("Brand: {0},Product: {1},Price: {2}\n",bp.Brand,bp.Product,bp.Price);
            }
        }


    }
}
