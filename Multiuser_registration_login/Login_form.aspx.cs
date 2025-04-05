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
    public partial class Login_form : System.Web.UI.Page
    {
        Con_class obj1 = new Con_class();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select Count(Reg_Id) from Login_tab where User_Name='" + TextBox1.Text + "' and Password ='" + TextBox2.Text + "'";
            string id = obj1.Fn_Scalar(str);
            int id1 = Convert.ToInt32(id);
            if (id1 == 1)
            {
                string str1 = "select Reg_Id from Login_tab where User_Name='" + TextBox1.Text + "' and Password ='" + TextBox2.Text + "'";
                string regid = obj1.Fn_Scalar(str1);
                Session["uid"] = regid;

                string str2 = "select Log_Type from Login_tab where user_Name='" + TextBox1.Text + "' and Password ='" + TextBox2.Text + "'";
                string logtype = obj1.Fn_Scalar(str2);
                if (logtype == "Admin")

                {

                    Label3.Visible = true;
                    Label3.Text = "Admin";

                }

                else if (logtype == "User")
                {

                    Label3.Visible = true;
                    Label3.Text = "User";

                }
            }
            else
            {
                Label4.Visible = true;
                Label4.Text = "Invalid username or Password";
            }
            }
        }
    }
