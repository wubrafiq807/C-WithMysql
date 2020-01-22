using ConsoleApp.Myinterface;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ConsoleApp.DB;

namespace ConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            ManageStudent manage = new ManageStudent();
            DBConnect Db = new DBConnect();           
            foreach (Student student1 in manage.getData())
            {
                manage.insertStudent(student1);

            }
          

        }
    }

    class ManageStudent : dataModel
    {
        DBConnect Db = new DBConnect();
        public List<Student> getData()
        {

            List<Student> students = new List<Student>();

            for (int i = 0; i <= 1000; i++)
            {
                Student student = new Student();
                student.setStudentEmail("mail+" + i + "@mail.com");
                student.setStudentName("testName-" + i);
                student.setDepartment("Department-" + i);
                student.setName("Class-" + i);
                students.Add(student);
            }
            return students;
        }

        public void insertStudent(Student student)
        {
            string query = "INSERT INTO student set name='"+student.getStudentName()+"',email='"+student.getStudentEmail()+"',dept='"+student.getDepartment()+ "',class_name='"+student.getName()+"'";

            //open connection
            if (Db.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, Db.GetConnection());

                //Execute command
                cmd.ExecuteNonQuery();
                Db.CloseConnection();

            }
            else {
                Console.WriteLine("falied");
            }
        }
    }

    class Student : StudentClass
    {

        private String studentName;
        private String studentEmail;

        public String getStudentName()
        {
            return this.studentName;
        }

        public void setStudentName(String studentName)
        {
            this.studentName = studentName;
        }

        public String getStudentEmail()
        {
            return this.studentEmail;
        }

        public void setStudentEmail(String studentEmail)
        {
            this.studentEmail = studentEmail;
        }

        
    }

    class StudentClass
    {

        private String name;
        private String department;

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getDepartment()
        {
            return this.department;
        }

        public void setDepartment(String department)
        {
            this.department = department;
        }

    }
}
