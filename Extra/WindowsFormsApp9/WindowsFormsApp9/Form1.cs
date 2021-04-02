using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = new SqlConnection();
        private static ConnectionStringSettings Connsetting = ConfigurationManager.ConnectionStrings["mongodb"];
        string ConnString = Connsetting.ConnectionString;
        //private string conString = "Server = DESKTOP-UQ20I4G\\SQLEXPRESS; Database = abc; User = sa; password = sql123456";
        private SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = ConnString;
            cmd = conn.CreateCommand();

            try
            {
                string query = "abc_insert";
                cmd.CommandText = query;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;

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

        private void insert_Click(object sender, EventArgs e)
        {
            string id = abc_id.Text;
            string name = abc_name.Text;
            string department = abc_department.Text;
            string age = abc_age.Text;

            if ((id == "") || (name == "") || (department == "") || (age == ""))
            {
                string msg = "No text box can be empty";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.ConnectionString = ConnString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "abc_insertdata";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar);
                    cmd.Parameters["@id"].Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar);
                    cmd.Parameters["@name"].Value = name;
                    cmd.Parameters.Add("@department", SqlDbType.VarChar);
                    cmd.Parameters["@department"].Value = department;
                    cmd.Parameters.Add("@age", SqlDbType.VarChar);
                    cmd.Parameters["@age"].Value = age;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    MessageBox.Show("Successfully Saved.");
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
        private void refresh_Click(object sender, EventArgs e)
        {
            Form1_Load(this, e);
            textdefault();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(abc_id.Text);
            if (id != 0)
            {
                conn.ConnectionString = ConnString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "abc_delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar);
                    cmd.Parameters["@id"].Value = id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    MessageBox.Show("Delete Sucessfull.");
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

        private void search_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(abc_search.Text);

            string id1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int id2 = Convert.ToInt32(id);

            if (id == id2)
            {
                conn.ConnectionString = ConnString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "abc_search";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar);
                    cmd.Parameters["@id"].Value = id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dataGridView1.DataSource = dt;
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
                MessageBox.Show("No data found!");
            }
        }

        private void message_Click(object sender, EventArgs e)
        {
            String a = abc_id.Text;
            String d = abc_name.Text;
            String g = abc_department.Text;
            String h = abc_age.Text;
            MessageBox.Show("Welcome " + a + "\nYour ID: " + d + "\nName: " + g + "\nyour department +");
        }
        public void textdefault()
        {
            abc_id.Text = "";
            abc_name.Text = "";
            abc_department.Text = "";
            abc_age.Text = "";
            abc_search.Text = "";
        }

        private void update_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int id2 = Convert.ToInt32(id);

            conn.ConnectionString = ConnString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "abc_update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar);
                cmd.Parameters["@id"].Value = abc_id.Text;
                cmd.Parameters.Add("@name", SqlDbType.VarChar);
                cmd.Parameters["@name"].Value = abc_name.Text;
                cmd.Parameters.Add("@department", SqlDbType.VarChar);
                cmd.Parameters["@department"].Value = abc_department.Text;
                cmd.Parameters.Add("@age", SqlDbType.VarChar);
                cmd.Parameters["@age"].Value = abc_age.Text;
                cmd.Parameters.AddWithValue("@id2", id2);
                cmd.CommandText = query;

                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();
                MessageBox.Show("Done!");
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;

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
        //double click
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            abc_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            abc_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            abc_department.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            abc_age.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void refresh_Click_1(object sender, EventArgs e)
        {
            Form1_Load(this, e);
            textdefault();
        }
    }

}
        
    
