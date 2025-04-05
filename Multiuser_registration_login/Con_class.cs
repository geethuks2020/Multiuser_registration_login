using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Multiuser_registration_login
{
    public class Con_class
    {

        SqlConnection con;//object created 
        SqlCommand cmd;

        public Con_class()
        {
            con = new SqlConnection(@"Server=DESKTOP-8R7JP3N\SQLEXPRESS;Database=dbtwo_layer;Integrated Security = True");
        }
        public int Fn_NonQuery(string sqlquery)//insert,update,delete
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_Scalar(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);//scalar function
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;

        }
        public SqlDataReader Fn_DataReader(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }
}