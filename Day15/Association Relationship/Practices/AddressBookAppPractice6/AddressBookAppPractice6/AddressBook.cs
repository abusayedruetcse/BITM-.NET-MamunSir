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
            messageLabel.Text = "";
            if(SaveButton.Text.Equals("Save"))
            {
                person = new Person();
                person.FirstName = firstNameTextBox.Text;
                person.LastName = lastNameTextBox.Text;
                //person.Email = emailTextBox.Text;
                foreach(Person aPerson in persons)
                {
                    if(aPerson.Email.Equals(emailTextBox.Text))
                    {
                        messageLabel.Text = "Email is Duplicate";
                        return;
                    }
                }
                if (person.SetEmail(emailTextBox.Text))
                {
                    messageLabel.Text = "Enter a valid Email";
                    return;
                }
                person.PhoneNo = phoneNoTextBox.Text;
                persons.Add(person);
            } 
            else
            {
                foreach (Person aPerson in persons)
                {
                    if (aPerson.Email.Equals(emailTextBox.Text))
                    {
                        person = aPerson;                        
                        break;
                    }
                }
                person.FirstName=firstNameTextBox.Text ;
                person.LastName = lastNameTextBox.Text;
                person.PhoneNo = phoneNoTextBox.Text;
                SaveButton.Text = "Save";
                editEmailTextBox.Text = "";
            }
            //cleaning textbox
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            phoneNoTextBox.Text = "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            string email = editEmailTextBox.Text;
            foreach(Person aPerson in persons)
            {
                if(aPerson.Email.Equals(email))
                {
                    person = aPerson;
                    firstNameTextBox.Text = person.FirstName;
                    lastNameTextBox.Text = person.LastName;
                    emailTextBox.Text = person.Email;
                    phoneNoTextBox.Text = person.PhoneNo;
                    SaveButton.Text = "Confirm";
                    break;
                }
            }
            if(firstNameTextBox.Text.Equals(""))
            {
                messageLabel.Text = "Not found this person";
            }
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            List<Person> personList = new List<Person>();
            if(!String.IsNullOrEmpty(searchLastNameTextBox.Text))
            {
                personList = new List<Person>();
                foreach (Person aPerson in persons)
                {
                    if(aPerson.LastName.Equals(searchLastNameTextBox.Text))
                    {
                        personList.Add(aPerson);
                    }
                }   
                if(personList.Count==0)
                {
                    messageLabel.Text = "Not Found for this Last Name";
                }
            } 
            if(!String.IsNullOrEmpty(searchEmailTextBox.Text))
            {
                personList = new List<Person>();
                foreach(Person aPerson in persons)
                {
                    if(aPerson.Email.Equals(searchEmailTextBox.Text))
                    {
                        personList.Add(aPerson);
                        break;
                    }
                }
                if (personList.Count == 0)
                {
                    messageLabel.Text = "Not Found for this Email";
                }
            }
            if (!String.IsNullOrEmpty(searchPhoneNoTextBox.Text))
            {
                personList = new List<Person>();
                foreach (Person aPerson in persons)
                {
                    if (aPerson.PhoneNo.Equals(searchPhoneNoTextBox.Text))
                    {
                        personList.Add(aPerson);
                        break;
                    }
                }
                if (personList.Count == 0)
                {
                    messageLabel.Text = "Not Found for this Phone No.";
                }
            }
            displayDataGridView.DataSource = personList;

        }
    }
}
