using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Multiuser_registration_login
{
    public partial class Admin_reg_form : System.Web.UI.Page
    {
        Con_class obj1 = new Con_class();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from Login_tab";
            string maxregid = obj1.Fn_Scalar(sel);
            int reg_id = 0;
            if(maxregid=="")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }
            string ins="insert into Admin_reg values("+reg_id+",'"+TextBox1.Text+"','"+TextBox2.Text+"')";
            int i = obj1.Fn_NonQuery(ins);
            if(i==1)
            {
                string inslog = "insert into Login_tab values(" + reg_id + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','Admin','Active')";
                int i1 = obj1.Fn_NonQuery(inslog);
                Label5.Visible = true;
            }

        }
    }
}