using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEntryAppExample2
{
    public partial class StudentEntryUi : Form
    {
        public StudentEntryUi()
        {
            InitializeComponent();
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            Person person = new Person("Abu", "Sayed", "Ahmad");
            studentNameTextBox.Text = person.GetName();
        }
    }
}
