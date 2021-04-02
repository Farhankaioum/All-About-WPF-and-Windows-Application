using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;


using System.Configuration;

namespace HellowWorld
{
    class DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Paroll_HRM"].ConnectionString);


        public DataTable DataBind(string ProcedureName)
        {
            SqlDataAdapter sda = new SqlDataAdapter(ProcedureName, con);//spGetAllStudentReg

            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }
        public DataTable DataBindByUniqueID(string ProcedureName, SqlCommand cmd)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();


            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;


        }

        public int Insert(string ProcedureName, SqlCommand cmd)
        {
            int i ;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = ProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
           i= cmd.ExecuteNonQuery();

           return i;
        }
    }
  

}
