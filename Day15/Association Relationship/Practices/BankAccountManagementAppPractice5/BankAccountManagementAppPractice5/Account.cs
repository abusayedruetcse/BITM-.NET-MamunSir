using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementAppPractice5
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        private double balance;
        public Account()
        {
            balance = 0;
        } 
        public double Balance
        {
            get { return balance; }
        }
        public bool Deposit(double amount)
        {
            balance += amount;
            return true;
        } 
        public bool Withdraw(double amount)
        {
            if(balance>=amount)
            {
                balance -= amount;
                return true;
            } 
            else
            {
                return false;
            }
        }

    }
}
