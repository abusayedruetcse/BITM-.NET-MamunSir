using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountManagementAppPractice5
{
    public partial class BankAccountManagementUi : Form
    {
        List<Customer> customers;
        public BankAccountManagementUi()
        {
            InitializeComponent();
            customers = new List<Customer>();           
        }

        private void CustomerSaveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            foreach(Customer aCustomer in customers)
            {
                if(aCustomer.NationalID.Equals(idTextBox.Text))
                {
                    MessageBox.Show("Entered National ID no is duplicate!");
                    return;
                }
            }
            customer.NationalID = idTextBox.Text;
            customer.Name = nameTextBox.Text;
            customer.Phone = phoneTextBox.Text;
            customer.PresentAddress = addressTextBox.Text;
            customers.Add(customer);                             
            //cleaning
            idTextBox.Text = "";
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
        }

        private void AccountSaveButton_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            foreach(Customer aCustomer in customers)
            {
                foreach(Account aAccount in aCustomer.GetAccounts)
                {
                    if(aAccount.AccountNumber.Equals(accountNumTextBox.Text))
                    {
                        MessageBox.Show("Entered Account Number is Duplicate!");
                        return;
                    }
                }
            }
            account.AccountNumber = accountNumTextBox.Text;
            account.Type = typeComboBox.Text;
            foreach(Customer customer in customers)
            {
                if(customer.NationalID.Equals(customerComboBox.SelectedValue.ToString()))
                {
                    customer.AddAccount(account);
                    accountNumTextBox.Text = "";
                    typeComboBox.Text = "";
                    customerComboBox.Text = "";
                    break;
                }
            }            
        }

        private void transactionCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Customer customer in customers)
            {
                if (customer.NationalID.Equals(transactionCustomerComboBox.SelectedValue.ToString()))
                {
                    accountComboBox.DataSource = customer.GetAccounts;
                    break;
                }
            }
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            Customer customer=null;
            foreach(Customer aCustomer in customers)
            {
                if(aCustomer.NationalID.Equals(transactionCustomerComboBox.SelectedValue.ToString()))
                {
                    customer = aCustomer;
                    break;
                }
            }
            Account account = null;
            foreach(Account aAccount in customer.GetAccounts)
            {
                if(aAccount.AccountNumber.Equals(accountComboBox.SelectedValue.ToString()))
                {
                    account = aAccount;
                    break;
                }
            }
            account.Deposit(amount);
            transactionCustomerComboBox.Text = "";
            accountComboBox.Text = "";
            amountTextBox.Text = "";
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            Customer customer = null;
            foreach (Customer aCustomer in customers)
            {
                if (aCustomer.NationalID.Equals(transactionCustomerComboBox.SelectedValue.ToString()))
                {
                    customer = aCustomer;
                    break;
                }
            }
            Account account = null;
            foreach (Account aAccount in customer.GetAccounts)
            {
                if (aAccount.AccountNumber.Equals(accountComboBox.SelectedValue.ToString()))
                {
                    account = aAccount;
                    break;
                }
            }
            account.Withdraw(amount);
            transactionCustomerComboBox.Text = "";
            accountComboBox.Text = "";
            amountTextBox.Text = "";
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Customer customer = null;
            foreach (Customer aCustomer in customers)
            {
                if (aCustomer.NationalID.Equals(reportCustomerComboBox.SelectedValue.ToString()))
                {
                    customer = aCustomer;
                    break;
                }
            }           
            MessageBox.Show(customer.ShowAccountInfo());
            reportCustomerComboBox.Text = "";

        }

        private void transactionCustomerComboBox_Click(object sender, EventArgs e)
        {
            transactionCustomerComboBox.DataSource = customers;
        }

        private void customerComboBox_Click(object sender, EventArgs e)
        {
            customerComboBox.DataSource = customers;                                               
        }

        private void reportCustomerComboBox_Click(object sender, EventArgs e)
        {
            reportCustomerComboBox.DataSource = customers;
        }
    }
}
