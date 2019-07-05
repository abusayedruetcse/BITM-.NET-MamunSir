using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentWiseStudentEntryExample3
{
    public partial class DepartmentWiseStudentEntryUi : Form
    {
        List<Department> departments;         
        public DepartmentWiseStudentEntryUi()
        {
            InitializeComponent();
            departments = new List<Department>();
        }

        private void DepartmentSaveButton_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Code = codeTextBox.Text;
            department.Name = departmentNameTextBox.Text;
            departments.Add(department);
            codeTextBox.Text = "";
            departmentNameTextBox.Text = "";
        }

        private void StudentSaveButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.RegNo = regNoTextBox.Text;
            student.Name = studentNameTextBox.Text;
            student.Email = emailTextBox.Text;
            
            foreach(Department aDepartment in departments)
            {
                if(aDepartment.Code.Equals(departmentComboBox.SelectedValue))
                {
                    if(aDepartment.AddStudent(student))
                    {
                        regNoTextBox.Text = "";
                        studentNameTextBox.Text = "";
                        emailTextBox.Text = "";
                        departmentComboBox.Text = "";
                    }
                    break;
                }
            }

        }

        private void departmentComboBox_Click(object sender, EventArgs e)
        {
            departmentComboBox.DataSource = departments;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            foreach(Department aDepartment in departments)
            {
                if(aDepartment.Code.Equals(department2ComboBox.SelectedValue))
                {
                    MessageBox.Show(aDepartment.ShowStudents());
                    return;
                }
            }
            department2ComboBox.Text = "";
        }

        private void department2ComboBox_Click(object sender, EventArgs e)
        {
            department2ComboBox.DataSource = departments;
        }
    }
}
