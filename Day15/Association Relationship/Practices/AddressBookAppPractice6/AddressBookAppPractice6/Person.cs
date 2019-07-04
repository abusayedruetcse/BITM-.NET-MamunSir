using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAppPractice6
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; } 
        public bool SetEmail(string email)
        {
            bool isInvalid = false;
            if(!email.ToString().Contains("@")|| !email.ToString().Contains("."))
            {
                isInvalid = true;
            }
            else
            {
                Email = email;
            }
            return isInvalid;
        }
    }
}
