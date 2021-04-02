using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using system.configuration;
//using system.data.sqlClient;

namespace HellowWorld
{  
   

    public partial class Form1 : Form
    {
        
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            string name =Nametxt .Text ;
            MessageBox.Show("Hi, " + name + ". ");
        }

        private void studentRegSampleWayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEntrySimpleWay SW = new StudentEntrySimpleWay();
            SW.ShowDialog();


        }

        private void studentRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEntry SW = new StudentEntry();
            SW.ShowDialog();
        }
 
    }
}