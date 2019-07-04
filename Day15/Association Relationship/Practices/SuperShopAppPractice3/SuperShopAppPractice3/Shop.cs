using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShopAppPractice3
{
    public class Shop
    {
        public Shop()
        {
            products = new List<Product>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Product> products;
        public bool AddProduct(Product product)
        {
            bool isDuplicate = false;
            foreach(Product aProduct in products)
            {
                if(aProduct.Id==product.Id)
                {
                    aProduct.Quantity += product.Quantity;
                    isDuplicate = true;
                    break;
                }
            } 

            if(!isDuplicate)
            {
                products.Add(product);
            }
            return true;
        } 
        public string ShowDetails()
        {
            string message = "";
            string shopInfo = "Name: " + Name + " Address: " + Address;
            string header = "Product Id: \t\t Quantity \t\t ";
            string productInfo = "";
            foreach(Product aProduct in products)
            {
                productInfo += aProduct.Id + " \t\t " + aProduct.Quantity + " \t\t " + Environment.NewLine;
            }
            message += shopInfo + Environment.NewLine + header + Environment.NewLine + productInfo;
            return message;
        }

    }
}
