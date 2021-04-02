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


namespace CRUDLAB
{
    public partial class Form1 : Form
    {
        private string Id, Name, Department;
    

        SqlConnection conn = new SqlConnection();
        string connString = "Server =DESKTOP-J1NS0B9\\FARHANSQL; Database =TodayProject; User =sa; Password =sql123456";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conn.ConnectionString = connString;
            cmd = conn.CreateCommand();

            GetAllDataFromDB();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;
            Name = textBoxName.Text;
            Department = textBoxDept.Text;

            if((Id =="") || (Name =="") || (Department ==""))
            {
                MessageBox.Show("No input box is empty");
            }
            else
            {
                try
                {
                    int Id1 = Convert.ToInt32(Id);

                    string query = "sp_InsertData";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Id1;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters["@Name"].Value = Name;

                    cmd.Parameters.Add("@Dept", SqlDbType.NVarChar);
                    cmd.Parameters["@Dept"].Value = Department;

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    MessageBox.Show("Insert successfully!");

                    ClearTextBox();//clear all textbox value
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;
            Name = textBoxName.Text;
            Department = textBoxDept.Text;

            if ((Id == "") || (Name == "") || (Department == ""))
            {
                MessageBox.Show("No input box is empty");
            }
            else
            {
                try
                {
                    int Id1 = Convert.ToInt32(Id);

                    string query = "sp_Update_Data";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Id1;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters["@Name"].Value = Name;

                    cmd.Parameters.Add("@Dept", SqlDbType.NVarChar);
                    cmd.Parameters["@Dept"].Value = Department;


                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                    MessageBox.Show("Update successfully!");

                    ClearTextBox();//clear all textbox value
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxDept.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;
            try
            {
                int Id1 = Convert.ToInt32(Id);

                string query = "sp_Delete_Data";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Id1;

                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();
                MessageBox.Show("Delete successfully!");

                ClearTextBox();//clear all textbox value
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Id = textBoxSearch.Text;
            try
            {
                int Id1 = Convert.ToInt32(Id);

                string query = "sp_Search_Data";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Id1;

              
               
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
                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }

       

        private void GetAllDataFromDB()
        {
            string query = "spGetAllData";
            try
            {
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
                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        private void ClearTextBox()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxDept.Text = "";
        }
    }
}
