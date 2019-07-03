using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryAppPractice1
{
    public class Employee
    {
        private string id;
        private string name;
        private string email;
        private Salary salary;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Salary Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
    }
}
