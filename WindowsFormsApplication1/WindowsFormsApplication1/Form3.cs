using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form3_Load(object sender, EventArgs e)
        {


            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select course_id ,name,teacher,study_year from courses", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Course_Details");
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                course.ID = Convert.ToInt32(textBox5.Text);
                course.Name = textBox8.Text;
                course.Teacher = textBox7.Text;
                course.StudyYear = Convert.ToInt32(textBox6.Text);

                IDBManager db = new MySQLDBManager();
                db.AddCourse(course);
                BindingSource bindingsource = new BindingSource();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingsource;
                dataGridView2.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select course_id ,name,teacher,study_year from courses", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Course_Details");
                dataGridView2.DataSource = ds.Tables[0];
                MessageBox.Show("Information added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form0 frm = new Form0();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                course.ID = Convert.ToInt32(textBox5.Text);
                course.Name = textBox8.Text;
                course.Teacher = textBox7.Text;
                course.StudyYear = Convert.ToInt32(textBox6.Text);

                IDBManager db = new MySQLDBManager();
                db.UpdateCourse(course);
                BindingSource bindingsource = new BindingSource();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingsource;
                dataGridView2.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select course_id ,name,teacher,study_year from courses", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Course_Details");
                dataGridView2.DataSource = ds.Tables[0];
                MessageBox.Show("Informations updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                course.ID = Convert.ToInt32(textBox5.Text);
                course.Name = textBox8.Text;
                course.Teacher = textBox7.Text;
               // course.StudyYear = Convert.ToInt32(textBox6.Text);

                IDBManager db = new MySQLDBManager();
                db.DeleteCourse(course);
                BindingSource bindingsource = new BindingSource();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingsource;
                dataGridView2.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=application;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select course_id ,name,teacher,study_year from courses", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Course_Details");
                dataGridView2.DataSource = ds.Tables[0];
                MessageBox.Show("Informations deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                int course_id= Convert.ToInt32(textBox9.Text);
                int studnet_id = Convert.ToInt32(textBox10.Text);             
                IDBManager db = new MySQLDBManager();
                db.Enroll(studnet_id, course_id);
                MessageBox.Show("Student enrolled", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }


    
}
