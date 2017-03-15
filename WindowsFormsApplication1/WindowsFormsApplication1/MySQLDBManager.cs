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
    }
}
