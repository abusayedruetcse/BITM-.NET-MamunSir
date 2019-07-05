using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentWiseStudentEntryExample3
{
    public class Department
    {
        public string Code { get; set; }
        public string Name { get; set; }
        List<Student> students;
        public Department()
        {
            students = new List<Student>();
        } 
        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        } 
        public string ShowStudents()
        {
            string message = "";
            string deptHeader = "Dept. Code: " + Code + "Name: " + Name;
            string studentHeader = "Student Reg. No: \tName \tEmail";
            string info = "";
            foreach (Student aStudent in students)
            {
                info += aStudent.RegNo + " \t" + aStudent.Name + " \t" + aStudent.Email + Environment.NewLine;
            }
            if(students.Count==0)
            {
                info = "Not Student in this Department";
                message += deptHeader + Environment.NewLine + info;
            } 
            else
            {
                message += deptHeader + Environment.NewLine + studentHeader + Environment.NewLine + info;
            }
            return message;
        } 
        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
