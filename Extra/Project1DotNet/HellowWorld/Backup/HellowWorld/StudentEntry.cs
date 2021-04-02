using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace HellowWorld
{
    public partial class StudentEntry : Form
    {
       
        public StudentEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
          


            BOL b = new BOL();
            dataGridView1.DataSource = b.DataBind("spGetAllStudentReg");

        }

       

       

        private void button2_Click(object sender, EventArgs e)
        {
            BOL b = new BOL();
            b.Mobile =mobTxt .Text ;
            dataGridView1.DataSource = b.DataBindByMobileNo("spGetStudentByMobile");
             
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            BOL b = new BOL();
            b.StudentId =StudentIdTxt .Text ;
            b.FirstName = FirstNameTxt.Text;
            b.LastName = LastNameTxt.Text;
            b.age =Convert .ToInt16 ( AgeTxt.Text);
            b.Mobile  = mobTxt.Text;
            b.Mail = MailTxt.Text;

            b.Insert("spInsertStudentInformation");
        }

         

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}