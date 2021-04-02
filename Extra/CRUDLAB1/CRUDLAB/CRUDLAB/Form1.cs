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
        string Id, Name, Department;
        SqlConnection conn = new SqlConnection();
        string connString = "Server =DESKTOP-J1NS0B9\\FARHANSQL; Database =TodayProject; User =sa; Password =sql123456";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;
            Name = textBoxName.Text;
            Department = textBoxDept.Text;

            if ((Id == "") || (Name == "") || (Department == ""))
            {
                MessageBox.Show("No input box is empty!");
            }
            else
            {

                try
                {
                    int id1 = Convert.ToInt32(Id);

                    string query = "update tblStudentInfo set  Id = '"+id1+"', Name = '"+Name+"', Department = '"+Department+"' where Id = '"+id1+"'";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;

            try
                {
                    int id1 = Convert.ToInt32(Id);

                    string query = "delete tblStudentInfo  where Id = '" + id1 + "'";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = connString;
            cmd = conn.CreateCommand();

            string query = "select * from tblStudentInfo";
            try
            {
                cmd.CommandText = query;
                conn.Open();

               SqlDataReader  reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                reader.Close();


            }catch(Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }

        }


        void ClearBox()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxDept.Text = "";
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            Id = textBoxId.Text;
            Name = textBoxName.Text;
            Department = textBoxDept.Text;

            if((Id == "") || (Name =="") || (Department == ""))
            {
                MessageBox.Show("No input box is empty!");
            } else
            {

                try
                {
                    int id1 = Convert.ToInt32(Id);

                    string query = "sp_Insert_Data";

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = id1;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    cmd.Parameters["@Name"].Value = Name;

                    cmd.Parameters.Add("@Dept", SqlDbType.VarChar);
                    cmd.Parameters["@Dept"].Value = Department;





                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    ClearBox();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
