using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAndAccountAppExample1
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string OpeningDate { get; set; }
        private double Balance { get; set; }
        public Account()
        {
            Balance = 0;
        }
        public bool Deposit(double amount)
        {
            Balance += amount;
            return true;
        } 
        public bool Withdraw(double amount)
        {
            if(Balance>=amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        } 
        public double GetBalance()
        {
            return Balance;
        }
    }
}
