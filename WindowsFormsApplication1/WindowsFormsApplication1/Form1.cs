using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select student_id ,name,birth_date,address from students", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Student_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.ID = Convert.ToInt32(textBox1.Text);
                student.Name = textBox2.Text;
                student.BirthDate = dateTimePicker1.Value;
                student.Address = textBox3.Text;

                IDBManager db = new MySQLDBManager();
                db.AddStudent(student);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select student_id ,name,birth_date,address from students", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Student_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Information added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.ID = Convert.ToInt32(textBox1.Text);
                student.Name = textBox2.Text;
                student.BirthDate = dateTimePicker1.Value;
                student.Address = textBox3.Text;

                IDBManager db = new MySQLDBManager();
                db.UpdateStudent(student);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select student_id ,name,birth_date,address from students", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Student_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Informations updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.ID = Convert.ToInt32(textBox1.Text);
                student.Name = textBox2.Text;
                student.BirthDate = dateTimePicker1.Value;
                student.Address = textBox3.Text;

                IDBManager db = new MySQLDBManager();
                db.DeleteStudent(student);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select student_id ,name,birth_date,address from students", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Student_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Informations deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
