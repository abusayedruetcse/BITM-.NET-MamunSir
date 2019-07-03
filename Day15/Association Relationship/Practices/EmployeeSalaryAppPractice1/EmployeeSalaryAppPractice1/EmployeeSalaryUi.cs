using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSalaryAppPractice1
{
    public partial class EmployeeSalaryUi : Form
    {
        Employee employee;
        public EmployeeSalaryUi()
        {
            InitializeComponent();
            employee = new Employee();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            employee.Id = IdTextBox.Text;
            employee.Name = nameTextBox.Text;
            employee.Email = emailTextBox.Text;

            Salary salary = new Salary();
            salary.Basic = Convert.ToDouble(basicTextBox.Text);
            salary.RateOfMedical = Convert.ToDouble(medicalTextBox.Text);
            salary.RateOfConveyance = Convert.ToDouble(conveyanceTextBox.Text);

            employee.Salary = salary;
        }

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(increaseTextBox.Text);
            if(employee.Salary.Increment(amount))
            {
                increaseTextBox.Text = "";
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            noOfIncrementsTextBox.Text = employee.Salary.NoOfIncrement.ToString();
            showBasicTextBox.Text = employee.Salary.Basic.ToString();
            showMedicalTextBox.Text = employee.Salary.Medical.ToString();
            showConveyanceTextBox.Text = employee.Salary.Conveyance.ToString();
            showTotalTextBox.Text = employee.Salary.Total.ToString();
        }
    }
}
