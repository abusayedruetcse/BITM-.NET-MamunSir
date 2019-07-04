using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntryAppExample2
{
    public class Person
    {
        private string FirstName { get; set; }
        private string MidName { get; set; }
        private string LastName { get; set; }
        private double Balance { get; set; }

        public Person()
        {
            Balance = 500;
        }
        public Person(string firstName,string lastName):this()
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Person(string firstName,string midName,string lastName):this(firstName,lastName)
        {
            MidName = midName;
        }
        public string GetName()
        {
            return FirstName + MidName + LastName;
        }
    }
}
