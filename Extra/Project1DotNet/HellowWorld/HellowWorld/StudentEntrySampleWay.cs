using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
 
 
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
namespace HellowWorld
{
    public partial class StudentEntrySampleWay : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Paroll_HRM"].ConnectionString);

        public StudentEntrySampleWay()
        {
            InitializeComponent();
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Paroll_HRM"].ConnectionString);



            //BOL b = new BOL();
            //b.StudentId = StudentIdTxt.Text;
            //b.FirstName = FirstNameTxt.Text;
            //b.LastName = LastNameTxt.Text;
            //b.age = Convert.ToInt16(AgeTxt.Text);
            //b.Mobile = mobTxt.Text;
            //b.Mail = MailTxt.Text;

            string query = "insert into dbo.StudentReg (  StudentId, FirstName, LastName, Age, Mobile, Mail)    values('" + StudentIdTxt.Text + "', '" + FirstNameTxt.Text + "', '" + LastNameTxt.Text + "', '" + AgeTxt.Text + "', '" + mobTxt.Text + "', '" + MailTxt .Text + "')";

            SqlCommand cmd = new SqlCommand(query,con  );
            con.Open();
  
            cmd.ExecuteNonQuery();
  
            con.Close();
        }
        ReportViewer d = new ReportViewer();
        private void button3_Click(object sender, EventArgs e)
        {

            StudentList rprt = new StudentList();

            SqlCommand cmd = new SqlCommand("spGetAllStudentAndCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Newtbl_data");
            rprt.SetDataSource(ds);
            d.crystalReportViewer1.ReportSource = rprt;
            d.ShowDialog();
         
             
       
         

          //third_party_details   New CrystalReport1

        //    StudentList  third_party_details=new StudentList ();

        ////third_party_details.SetDataSource(ds.Tables("asdas"));
         
        //ReportViewer  viewer_lll= new ReportViewer() ;


 

        //viewer_lll.Text = "Patient Prescription";
        //  crystalReportViewer1.ReportSource = third_party_details;

        //viewer_lll.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}