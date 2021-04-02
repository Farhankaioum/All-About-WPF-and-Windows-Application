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
using System.Configuration;

namespace CRUDProject1
{
    public partial class Form1 : Form
    {
        int id;
        string name;
        string dept;
        int age;

        SqlConnection con = new SqlConnection();
        private string connstring = "Server=DESKTOP-QPLTNNK\\HRIDOY; Database=Seminar; User=sa; Password=123456";
        //private string connstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = connstring;
            cmd = con.CreateCommand();
            DataLoad();//for loading all info from db
        }
        private void DataLoad()
        {
            try
            {
                string query = "select * from tblInformation1";
                cmd.CommandText = query;
                con.Open();

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
                con.Close();
            }
        }
        private void TextBoxClear()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxDept.Text = "";
            textBoxAge.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32( textBoxId.Text);
             name = textBoxName.Text;
             dept = textBoxDept.Text;
             age = Convert.ToInt32( textBoxAge.Text);
            try
            {
                string query = "insert into tblInformation1 values('"+id+"', '"+name+"', '"+dept+"',  '"+age+"')";
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteScalar();
                MessageBox.Show("Data insert successfully!");

                TextBoxClear();
              
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                string caption = "Error";
                //MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Exception: "+ ex);


            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( textBoxSearch.Text);
            try
            {
                string query = "select * from tblInformation1 where ID = '"+id+"' ";
                cmd.CommandText = query;
                con.Open();

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
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxSearch.Text);
            try
            {
                string query = "delete from tblInformation1 where ID = '"+id+"'";
                cmd.CommandText = query;
                con.Open();

                cmd.ExecuteScalar();
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
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(textBoxId.Text);
            name = textBoxName.Text;
            dept = textBoxDept.Text;
            age = Convert.ToInt32(textBoxAge.Text);
            try
            {
                

                

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
                con.Close();
            }
        }
    }
}
