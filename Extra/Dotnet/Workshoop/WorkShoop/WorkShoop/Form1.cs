using HellowWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkShoop
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        string constring = "Server = DESKTOP-J1NS0B9\\FARHANSQL; Database = Utsho; User = sa; Password = sql123456";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = constring;
            cmd = conn.CreateCommand();

            try
            {
                string query = "select * from StudentReg ";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataShow1.DataSource = dt;
                reader.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int sid = 0;
            int age = 0;
            sid = Convert.ToInt32(StudentIdBox.Text);
            string firstName = FirstNameBox.Text;
            string lastName = LastNameBox.Text;
            string Email = EmailBox.Text;
            age = Convert.ToInt32(AgeBox.Text);

            if (  (firstName == "") || (lastName == "") || (Email == "") )
            {
                string msg = "No textbox can be empty";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd = conn.CreateCommand();
                try
                {
                    string query = "Insert into StudentReg values (' "
                            + sid + "','"
                            + firstName + "','"
                            + lastName + "','"
                            + Email + "','"
                            + age + "');";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    //for empty input box start
                    StudentIdBox.Text = "";
                    FirstNameBox.Text = "";
                    LastNameBox.Text = "";
                    EmailBox.Text = "";
                    AgeBox.Text = "";
                    MessageBox.Show("Data insert successfully!");

                    //for empty input box end

                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                    string caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentIdBox.Text = "";
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            EmailBox.Text = "";
            AgeBox.Text = "";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Form1_Load(this, e);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(updateBox.Text);
            if(id != 0)
            {

                cmd = conn.CreateCommand();
                try
                {
                    string query = "delete from StudentReg where S_Id = " + id;

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    //for empty input box start
                    StudentIdBox.Text = "";
                    FirstNameBox.Text = "";
                    LastNameBox.Text = "";
                    EmailBox.Text = "";
                    AgeBox.Text = "";
                    MessageBox.Show("Data Delete successfully!");

                    //for empty input box end

                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                    string caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

            } else
            {
                MessageBox.Show("Please enter valid id");
              
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(updateBox.Text);


            if (id != 0)
            {

                cmd = conn.CreateCommand();
                try
                {
                    string query = "select * from StudentReg where S_Id = " + id;

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataShow1.DataSource = dt;
                    reader.Close();


                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                    string caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

            }
            else
            {
                MessageBox.Show("Please enter valid id");

            }
        }

        private void datagrid(object sender, DataGridViewCellEventArgs e)
        {
            FirstNameBox.Text = dataShow1.CurrentRow.Cells[1].Value.ToString();
            StudentIdBox.Text = dataShow1.CurrentRow.Cells[0].Value.ToString(); 
            FirstNameBox.Text = dataShow1.CurrentRow.Cells[2].Value.ToString(); 
            LastNameBox.Text = dataShow1.CurrentRow.Cells[3].Value.ToString(); 
            EmailBox.Text = dataShow1.CurrentRow.Cells[4].Value.ToString(); 
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

