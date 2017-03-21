using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public class MySQLDBManager : IDBManager
    {
        private string connString;

        public MySQLDBManager()
        {
            connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=application;";
        }

       
        public void AddStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO students(student_id, name, birth_date, address) VALUES(@student_id, @name, @birth_date, @address)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@student_id", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@birth_date", student.BirthDate);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE students SET name='"+student.Name+"',birth_date='"+student.BirthDate+"',address='"+student.Address+"' WHERE student_id="+student.ID+";";
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from students where student_id=@student_id;";
                cmd.Parameters.AddWithValue("@student_id", student.ID);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }
        public Student SelectStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT student_id as student_id, name as name, birth_date as birth_date, address as address from students where student_id=@student_id;";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@student_id", student.ID);
                var reader = cmd.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(reader.GetOrdinal("student_id"));
                string name =reader["name"].ToString();
                DateTime dateb = reader.GetDateTime(reader.GetOrdinal("birth_date"));
                string address = reader["address"].ToString();
                Student s = new Student();
                s.ID = id;
                s.Name = name;
                s.BirthDate = dateb;
                s.Address = address;
                return s;
            }
        }
        public void AddCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO courses(course_id, name, teacher, study_year) VALUES(@course_id, @name, @teacher, @study_year)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@course_id", course.ID);
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.Parameters.AddWithValue("@teacher", course.Teacher);
                cmd.Parameters.AddWithValue("@study_year", course.StudyYear);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE courses SET name='" + course.Name + "',teacher='" + course.Teacher + "',study_year='" + course.StudyYear + "' WHERE course_id=" + course.ID + ";";
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from courses where course_id=@course_id;";
                cmd.Parameters.AddWithValue("@course_id", course.ID);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }
        public void Enroll(int student_id, int course_id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO students_enroll(student_id,course_id) VALUES(@student_id,@course_id)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.Parameters.AddWithValue("@course_id", course_id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
