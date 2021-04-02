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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection();
        String Constring = "Server=DESKTOP-J1NS0B9\\FARHANSQL; Database=sha;User=sa;Password=root";
        SqlCommand Cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con.ConnectionString = Constring;
            Cmd= Con.CreateCommand();
            try
            {
                String query = "Select * From student";
                Cmd.CommandText = query;
                Con.Open();
                SqlDataReader Reader= Cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(Reader);
                dataGridView1.DataSource = data;
                Reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Cmd.Dispose();
                Con.Close();
            }
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string PAvail = textBox3.Text;
            string expireDate = textBox4.Text;
           
            Con.ConnectionString = Constring;
            Cmd = Con.CreateCommand();
            try
            {
                string query = "insert into student values(' " + Id + " ',' " + name + " ',' " + PAvail + " ',' " + expireDate + " ')";
                Cmd.CommandText = query;
                Con.Open();
                Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cmd.Dispose();
                Con.Close();
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            Con.ConnectionString = Constring;
            Cmd = Con.CreateCommand();

            try
            {
                string query = "delete  from student where proll = " + id;
                Cmd.CommandText = query;
                Con.Open();
                Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cmd.Dispose();
                Con.Close();
            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);

            textBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string PAvail = textBox3.Text;
            string expireDate = textBox4.Text;

            Con.ConnectionString =Constring;
            Cmd = Con.CreateCommand();
            try
            {

                string query = "update student set proll = '" + Id + "',   pname = '" + name + "', psub = '" + PAvail + "', pphone = '" + expireDate + "' where proll = '" + Id + "'";
                Cmd.CommandText = query;
                Con.Open();
                Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cmd.Dispose();
                Con.Close();
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox1.Text);
            Con.ConnectionString = Constring;
            Cmd = Con.CreateCommand();
            try
            {
                String query = "Select * From student where proll = "+ Id;
                Cmd.CommandText = query;
                Con.Open();
                SqlDataReader Reader = Cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(Reader);
                dataGridView1.DataSource = data;
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Cmd.Dispose();
                Con.Close();
            }
        }
    }
}
