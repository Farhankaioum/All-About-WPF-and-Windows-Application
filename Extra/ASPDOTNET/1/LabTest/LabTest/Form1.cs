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

namespace LabTest
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        string conString = "Server=DESKTOP-J1NS0B9\\FARHANSQL; Database = ProductDB1; User = sa; Password = root";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = conString;
            cmd = con.CreateCommand();
            try
            {
                string query = "select * from ProductInformation";
                cmd.CommandText = query;
                con.Open();
                SqlDataReader reader =  cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }

        }

        private void Refreshbutton_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string PAvail = textBox3.Text;
            string expireDate = textBox4.Text;

            con.ConnectionString = conString;
            cmd = con.CreateCommand();
            try
            {
                string query = "insert into ProductInformation values(' "+Id+" ',' "+name+" ',' "+ PAvail + " ',' "+ expireDate + " ')";
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            con.ConnectionString = conString;
            cmd = con.CreateCommand();

            try
            {
                string query = "delete  from ProductInformation where PID = " + id;
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string PAvail = textBox3.Text;
            string expireDate = textBox4.Text;

            con.ConnectionString = conString;
            cmd = con.CreateCommand();
            try
            {
                
                string query = "update ProductInformation set PID = '"+Id+ "',   PName = '" + name+ "', PQuantityAvailable = '" + PAvail+ "', PExpiryDate = '" + expireDate + "' where PID = '"+Id+"'" ;
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
    }
}
