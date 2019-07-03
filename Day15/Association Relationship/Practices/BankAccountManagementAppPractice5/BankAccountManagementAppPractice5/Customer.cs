using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementAppPractice5
{
    public class Customer
    {
        public string NationalID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; } 
        public string PresentAddress { get; set; }
        private List<Account> accounts;

        public Customer()
        {
            accounts = new List<Account>();
        }
        public bool AddAccount(Account account)
        {
            accounts.Add(account);
            return true;
        } 
        public string ShowAccountInfo()
        {
            string message = "";
            string customerInfo = "Customer: " + Name + Environment.NewLine + "National ID: " + NationalID;
            string header = "Account No: \t\t Type \t\t Balance";
            string accountInfo = "";
            foreach(Account account in accounts)
            {
                accountInfo += account.AccountNumber + " \t\t " + account.Type + " \t\t " + account.Balance + Environment.NewLine;
            }
            message += customerInfo + Environment.NewLine + header + Environment.NewLine + accountInfo;
            return message;
        } 
        public List<Account> GetAccounts
        {
            get
            {
                return accounts;
            }
        }
    }
}
