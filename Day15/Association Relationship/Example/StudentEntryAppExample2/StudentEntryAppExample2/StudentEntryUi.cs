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
        Department department;
        Student student;
        public StudentEntryUi()
        {
            InitializeComponent();
            department = new Department();
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(department.ShowStudents());
        }

        private void DepartmentSaveButton_Click(object sender, EventArgs e)
        {
            department.Code = codeTextBox.Text;
            department.Name = departmentNameTextBox.Text;
        }

        private void StudentSaveButton_Click(object sender, EventArgs e)
        {
            student = new Student();
            student.RegNo = regNoTextBox.Text;
            student.Name = studentNameTextBox.Text;
            student.Email = emailTextBox.Text;
            if(department.GetStudents().Count<5)
            {
                department.AddStudent(student);
            }
            else
            {
                MessageBox.Show("Student is Overflow");
            }
            regNoTextBox.Text = "";
            studentNameTextBox.Text = "";
            emailTextBox.Text = "";

        }
    }
}
