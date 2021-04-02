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

namespace CRUDTest
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        
        string conString = "Server=DESKTOP-J1NS0B9\\FARHANSQL; Database = Utsho; User =sa; Password=root";

        public Form1()
        {
            InitializeComponent();
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString); 
        }
        void Reset()
        {
            txt_DeptName.Text = txt_ID.Text = txt_LocationId.Text = "";
            txt_ID.Focus();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            con.ConnectionString = conString;
            string id = txt_ID.Text;
            string command = "select * from dept where ID = @id";
            cmd = new SqlCommand(command, con);

            //cmd.Parameters.Add("@id", SqlDbType.VarChar);
            //cmd.Parameters["@id"].Value = id;

            cmd.Parameters.Add("@id", SqlDbType.VarChar);
            cmd.Parameters["@id"].Value = id;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_DeptName.Text = dr[1].ToString();
                txt_LocationId.Text = dr[2].ToString();
            }
            else
            {
                MessageBox.Show("Cannot find the record...", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            dr.Close();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
