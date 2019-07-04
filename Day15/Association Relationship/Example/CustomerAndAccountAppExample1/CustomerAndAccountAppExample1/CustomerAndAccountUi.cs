using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerAndAccountAppExample1
{
    public partial class CustomerAndAccountUi : Form
    {
        Customer customer;
        public CustomerAndAccountUi()
        {
            InitializeComponent();
            customer = new Customer();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            customer.Name = customerNameTextBox.Text;
            customer.Email = emailTextBox.Text;

            Account account = new Account();
            account.AccountNumber = accountNumberTextBox.Text;
            account.OpeningDate = openingDateTextBox.Text;

            customer.account = account;
        }

        private void DepositeButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            if(customer.account.Deposit(amount))
            {
                amountTextBox.Text = "";
            }
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            if (customer.account.Withdraw(amount))
            {
                amountTextBox.Text = "";
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            customerName2TextBox.Text = customer.Name;
            email2TextBox.Text = customer.Email;
            accountNumber2TextBox.Text = customer.account.AccountNumber;
            openingDate2TextBox.Text = customer.account.OpeningDate;
            BalanceTextBox.Text = customer.account.GetBalance().ToString();
        }
    }
}
