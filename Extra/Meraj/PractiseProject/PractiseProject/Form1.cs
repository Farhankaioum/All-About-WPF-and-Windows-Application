using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PractiseProject
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        String conString= "Server = DESKTOP-J1NS0B9\\FARHANSQL; Database = Meraj; User = sa; Password = root";
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
                String query = "MerajData";
                cmd.CommandText = query;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch(Exception ex)
            {
                String msg = ex.Message.ToString();
                String caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SId = Convert.ToInt32(StudentId.Text);
            String firstName = Fname.Text;
            String lastName = Lname.Text;
            String email = Email.Text;


            if((firstName=="")|| (lastName == "") || (email == ""))
            {
                MessageBox.Show("No text box can be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd = con.CreateCommand();
                try
                {
                    String query = "Insert into StudentInfo values('"
                        + SId + "','"+ firstName + "','"+ lastName + "','"+ email + "')";
                    cmd.CommandText = query;
                    con.Open();
                    cmd.ExecuteScalar();

                    StudentId.Text = "";
                    Fname.Text = "";
                    Lname.Text = "";
                    Email.Text = "";
                    MessageBox.Show("Data inserted succeessfully...");

                }
                catch(Exception ex)
                {
                    String msg = ex.Message.ToString();
                    String caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }
    }
}
