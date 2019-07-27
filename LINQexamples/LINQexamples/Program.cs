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
            //LINQ101ProjectionSelect(products);
            //LINQ101GroupingGroupBy(products);
            //LINQ101Element(products);
            //LINQ101Quantifiers(products);
            //LINQ101AggregateOperators(products);
            LINQ101ConversionOperators(products);
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
                                     //orderby p.Name descending
                                     //orderby p.Name,p.Price descending                                   
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
                                          .OrderBy(p => p.Name)
                                          //.OrderByDescending(p => p.Name)                                          
                                          .Select(p=>p);
                                          //.Reverse()
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
                                     //where o.OrderDate >= new DateTime(1998, 1, 1) this can be used.
                                     select new { Brand = b.Name, Product = p.Name, Price = p.Price };
            foreach(var bp in brandsProductsList)
            {
                Console.WriteLine("Brand: {0},Product: {1},Price: {2}\n",bp.Brand,bp.Product,bp.Price);
            }
            //6. Multiple from clause
            Console.WriteLine("6. Multiple from clause\n\n");
            var productFromFilteredBrandList = from b in brands
                                               where b.Name.Contains("RFL")
                                               from p in b.Products
                                               where p.Price > 1500
                                               select new { Brand = b.Name, Product = p.Name, Price = p.Price };
            foreach (var bp in productFromFilteredBrandList)
            {
                Console.WriteLine("Brand: {0},Product: {1},Price: {2}\n", bp.Brand, bp.Product, bp.Price);
            }

        }
        static private void LINQ101GroupingGroupBy(List<Product> products)
        {
            //1.Group by %5
            Console.WriteLine("1.Group by %5\n\n");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups =
                from n in numbers
                group n by n % 5 into g
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
            //2. Group by first letter of products.
            Console.WriteLine("2. Group by first letter of products.\n\n");
            var firstLetterBasedProductList = from p in products
                                              group p by p.Name[0] into g
                                              orderby g.Key 
                                              select new { key = g.Key, Products = g.ToList() };

            foreach (var g in firstLetterBasedProductList)
            {
                Console.WriteLine("Key: " + g.key);
                foreach (var pg in g.Products)
                {
                    Console.WriteLine("\t\tId: " + pg.Id + " Name: " + pg.Name + " Price: " + pg.Price + Environment.NewLine);
                }
            }
        }
        static private void LINQ101Element(List<Product> products)
        {
            //1. First Simple/Condition
            Console.WriteLine("1. First Simple/Condition\n\n");
            var firstProduct = products
                                    .Where(p => p.Price > 2000)
                                    .Select(p => p)
                                    .First();
                                    //.First(p=>p.Id>4);
            Console.WriteLine("Id: " + firstProduct.Id + " Name: " + firstProduct.Name + " Price: " + firstProduct.Price + Environment.NewLine);
            
            //2. FirstOrDefault
            Console.WriteLine("2. FirstOrDefault\n\n");    //if not found then assign relevant default value.
            var firstOrDefaultProduct = products
                                             .FirstOrDefault();
                                             //.FirstOrDefault(p=>p.Name.Contains("B"));
            Console.WriteLine("Id: " + firstOrDefaultProduct.Id + " Name: " + firstOrDefaultProduct.Name + " Price: " + firstOrDefaultProduct.Price + Environment.NewLine);

            //3. ElementAt(position_index)
            Console.WriteLine("3. ElementAt(position_index)\n\n");
            var elementAtProduct = products
                                          .Where(p => p.Price > 2000)
                                          .Select(p => p)
                                          .ElementAt(1);    //start from 0-index        
            Console.WriteLine("Id: " + elementAtProduct.Id + " Name: " + elementAtProduct.Name + " Price: " + elementAtProduct.Price + Environment.NewLine);
        }
        static private void LINQ101Quantifiers(List<Product> products)
        {
            //1. Any Simple
            Console.WriteLine("1. Any Simple\n\n");
            bool isExist = products
                                //.Any();                        //without condition
                                .Any(p => p.Price == 200);   //with condition
            if(isExist)
            {
                Console.WriteLine("There exists\n");
            } 
            else
            {
                Console.WriteLine("NO exists\n");
            }
            //2. Any Grouply   
            Console.WriteLine("2. Any Grouply  \n\n");
            var productGroups = from p in products
                                group p by p.Name into g
                                where g.Any(q => q.Name.Contains("d"))
                                select new { Key = g.Key, Products = g.ToList() };
            foreach(var g in productGroups)
            {
                Console.WriteLine("Key: " + g.Key);
                Display(g.Products);
            }
            //3. All Simple 
            Console.WriteLine("3. All Simple \n\n");
            bool isAllValid = products
                                   .All(p => p.Price > 200);
            if (isAllValid)
            {
                Console.WriteLine("Yes All valid\n");
            }
            else
            {
                Console.WriteLine("NO all valid\n");
            }
            //4. All Grouply
            Console.WriteLine("4. All Grouply\n\n");
            var productGroupAll = from p in products
                                  group p by p.Name into g
                                  where g.All(p => p.Price > 500)
                                  select new { key = g.Key, Products = g.ToList() };
            foreach (var g in productGroupAll)
            {
                Console.WriteLine("Key: " + g.key);
                Display(g.Products);
            }
        }
        static private void LINQ101AggregateOperators(List<Product> products)
        {
            int[] numbers = { 2, 2, 3, 5, 5 ,5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //1. Count: Simple- Conditional- Grouped
            Console.WriteLine("1. Count: Simple- Conditional- Grouped\n\n");
            var totalDistinctNumbers = numbers
                                            .Distinct()
                                            //.Count();    //simple   
                                            .Count(n=>n%2==1); //conditional
            Console.WriteLine("Total Distinct Product: " + totalDistinctNumbers+Environment.NewLine);
            var countGroupProduct = from p in products
                                    group p by p.Name into g
                                    select new { key = g.Key, NoOfProducts = g.Count() }; //grouped
            foreach(var g in countGroupProduct)
            {
                Console.WriteLine("Key: " + g.key +"  NoOfProducts: "+g.NoOfProducts+ Environment.NewLine);                
            }
            //2. Sum/Min/Max/Average: Simple-Projection-Group
            Console.WriteLine("2. Sum: Simple-Projection-Group\n\n");
            var sumNumbers = numbers
                                    //.Sum(); //simple
                                    //.Min();
                                    //.Max();
                                    .Average();
            Console.WriteLine("Sum/Min/Max/Average: " + sumNumbers + Environment.NewLine);
            var sumPrice = products
                                //.Sum(p => p.Price); //projection
                                //.Min(p => p.Price);
                                //.Max(p => p.Price);
                                .Average(p => p.Price);
            Console.WriteLine("Sum/Min/Max/Average of Price: " + sumPrice + Environment.NewLine);
            var sumPriceGrouply = from p in products
                                  group p by p.Name into g
                                  //select new { key = g.Key, GroupTotalPrice = g.Sum(p => p.Price) }; //grouped
                                  //select new { key = g.Key, GroupTotalPrice = g.Min(p => p.Price) };
                                  //select new { key = g.Key, GroupTotalPrice = g.Max(p => p.Price) };
                                  select new { key = g.Key, GroupTotalPrice = g.Average(p => p.Price) };
            foreach (var g in sumPriceGrouply)
            {
                Console.WriteLine("Key: " + g.key + "  ProductPriceSum/Min/Max/Average: " + g.GroupTotalPrice + Environment.NewLine);
            }
            //3. Max-Min Elements
            Console.WriteLine("3. Max-Min Elements\n\n");
            var criticalProductsInGroup = from p in products
                                          group p by p.Name into g
                                          //let criticalPrice = g.Max(p => p.Price)
                                          let criticalPrice = g.Min(p => p.Price)
                                          select new { key = g.Key, CriticalElements = g.Where(p => p.Price == criticalPrice) };
            foreach(var g in criticalProductsInGroup)
            {
                Console.WriteLine("Key: " + g.key + Environment.NewLine);
                Display(g.CriticalElements);
            }

        }
        static private void LINQ101ConversionOperators(List<Product> products)
        {
            var productList = from p in products
                              where p.Price > 500
                              select p;
            var toArray = productList.ToArray();
            var toList = productList.ToList();
            var toDictonary = productList.ToDictionary(x=>x.Id);
            //1. Conversion To Array 
            Console.WriteLine("1. Conversion To Array \n\n");
            for(int i=0; i<toArray.Length; i++)
            {
                Console.WriteLine("Name: " + toArray[i].Name + Environment.NewLine);
            }
            //2. Conversion To List 
            Console.WriteLine("1. Conversion To List \n\n");
            for (int i = 0; i < toList.Count; i++)
            {
                Console.WriteLine("Name: " + toList[i].Name + Environment.NewLine);
            }
            //3. Conversion To Dictionary 
            Console.WriteLine("1. Conversion To Dictionary \n\n");      
            Console.WriteLine(toDictonary[3].Name+ Environment.NewLine);
        }


    }
}
