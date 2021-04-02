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

namespace InformationDatabase1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        string constring = "Server = DESKTOP-J1NS0B9\\FARHANSQL; Database = informationDatabase1; User = sa; Password = root";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'informationDatabase1DataSet1.informationDBTable1' table. You can move, or remove it, as needed.
            //this.informationDBTable1TableAdapter.Fill(this.informationDatabase1DataSet1.informationDBTable1);

            conn.ConnectionString = constring;
            cmd = conn.CreateCommand();

            try
            {
                string query = "select * from informationDBTable1";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();

            } catch(Exception ex)
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string address = addressBox.Text;
            string gender = genderBox.Text;
            string phoneNumber = phoneBox.Text;
            string email = emailBox.Text;

            if((name == "") || (address == "") || (gender =="") || (phoneNumber =="") || (email == "") )
            {
                string msg = "No textbox can be empty";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                cmd = conn.CreateCommand();
                try
                {
                    string query = "Insert into informationDBTable1 values (' "
                            + name + "','"
                            + address + "','"
                            + gender + "','"
                            + phoneNumber + "','"
                            + email + "');";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    nameBox.Text = "";
                    addressBox.Text = "";
                    genderBox.Text = "";
                    phoneBox.Text = "";
                    emailBox.Text = "";
                    MessageBox.Show("Data insert successfully!");


                } catch(Exception ex)
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
    }
}
