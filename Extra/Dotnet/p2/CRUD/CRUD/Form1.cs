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

namespace CRUD
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = new SqlConnection();
        private string ConString = "Server=DESKTOP-J1NS0B9\\FARHANSQL; Database = NetClass; User = sa; Password = sql123456";
        private SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'netClassDataSet.UserInfo' table. You can move, or remove it, as needed.
           // this.userInfoTableAdapter.Fill(this.netClassDataSet.UserInfo);

            conn.ConnectionString = ConString;
            cmd = conn.CreateCommand();

            try
            {
                string query = "select * from UserInfo";
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
            string email = emailBox.Text;
            string phone = phoneBox.Text;

            if((name =="") || (address == "") || (email =="") || (phone ==""))
            {
                string msg = "No textbox can be empty";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                //conn.ConnectionString = ConString;
                cmd = conn.CreateCommand();

                try {

                    string query = "Insert into UserInfo values('"
                        + name + "','"
                        + address + "','"
                        + email + " ',' "
                        + phone + " '); ";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                        

                } catch(Exception e1)
                {
                    string msg = e1.Message.ToString();
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
