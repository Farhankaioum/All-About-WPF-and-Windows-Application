using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HellowWorld
{
    class BOL
    {
          DAL  d =new DAL ();
        public string FirstName  ;
        public string LastName  ;
        public string Mobile;
        public int age;
        public string StudentId;
        public string Mail;
        SqlCommand cmd =new SqlCommand ();

        public DataTable  DataBind(string ProcedureName)
        {
          
            return d.DataBind(ProcedureName);
        
        }

        public DataTable DataBindByMobileNo(string ProcedureName)
        {
            DAL d = new DAL();

            cmd.Parameters .AddWithValue ("Mobile",Mobile  );

           
         return   d.DataBindByUniqueID(ProcedureName,cmd);

        }

 
      public int  Insert(string ProcedureName)
        {
            DAL d = new DAL();

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@StudentId", StudentId );

            cmd.Parameters.AddWithValue("@mail", Mail );
         return   d.Insert(ProcedureName,cmd);

        }
    }
}
