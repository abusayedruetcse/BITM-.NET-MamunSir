using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookAppPractice6
{
    public partial class AddressBook : Form
    {
        List<Person> persons;
        Person person;
        public AddressBook()
        {
            InitializeComponent();
            persons = new List<Person>();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            person = new Person();
            person.FirstName = firstNameTextBox.Text;
            person.LastName = lastNameTextBox.Text;
            //person.Email = emailTextBox.Text;
            if(person.SetEmail(emailTextBox.Text))
            {
                MessageBox.Show("Enter a valid Email");
                return;
            }
            person.PhoneNo = phoneNoTextBox.Text;
            persons.Add(person);
            //cleaning textbox
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            phoneNoTextBox.Text = "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            foreach(Person aPerson in persons)
            {
                if(aPerson.Email.Equals(email))
                {
                    person = aPerson;
                    firstNameTextBox.Text = person.FirstName;
                    lastNameTextBox.Text = person.LastName;
                    emailTextBox.Text = person.Email;
                    phoneNoTextBox.Text = person.PhoneNo;
                    break;
                }
            }
            if(firstNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Not found this person");
            }
        }
    }
}
