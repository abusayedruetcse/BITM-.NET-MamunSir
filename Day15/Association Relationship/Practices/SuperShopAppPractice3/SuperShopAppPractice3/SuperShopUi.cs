using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopAppPractice3
{
    public partial class SuperShopUi : Form
    {
        Shop shop;
        public SuperShopUi()
        {
            InitializeComponent();
            shop = new Shop();
        }

        private void ShopSaveButton_Click(object sender, EventArgs e)
        {
            shop.Name = nameTextBox.Text;
            shop.Address = addressTextBox.Text;
        }

        private void ProductSaveButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Id = itemTextBox.Text;
            product.Quantity = Convert.ToInt32(quantityTextBox.Text);
            bool isAdded=shop.AddProduct(product);
            if(isAdded)
            {
                MessageBox.Show("Saved");
            } 
            else
            {
                MessageBox.Show("Not Saved");
            }
            
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(shop.ShowDetails());
        }
    }
}
