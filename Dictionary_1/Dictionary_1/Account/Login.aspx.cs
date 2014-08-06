using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace Dictionary_1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
             SqlConnection conn = new SqlConnection("Data Source=MAITRANG;Initial Catalog=TuDien;Integrated Security=True");
             conn.Open();
             string checkuser = "select count(*) from Administrators where [Username] like N'" + TextBoxUser.Text + "' ";
             SqlCommand _com = new SqlCommand(checkuser, conn);
             int temp = Convert.ToInt32(_com.ExecuteScalar().ToString());
            // string userID = _com.ExecuteScalar().ToString(); 
             conn.Close();
             if (temp != 0)
             {
                 conn.Open();
                 string CheckPassQuery = "select Password from Administrators where  Username like N'" + TextBoxUser.Text + "'";
                 SqlCommand passCom = new SqlCommand(CheckPassQuery, conn);
                 string pass = passCom.ExecuteScalar().ToString().Replace(" ","");
                 if (pass == TextBoxPass.Text)
                 {
                     Session["New"]= TextBoxUser.Text;
                     //Response.Write("<script LANGUAGE='JavaScript' >alert('Password is not correct')</script>");
                     Response.Redirect("~/Account/AdminPage.aspx");
                     
                 }
                 else
                 {
                     Response.Write("<script LANGUAGE='JavaScript' >alert('Password is not correct')</script>");
                 }
             }
             else
             {
                 Response.Write("<script LANGUAGE='JavaScript' >alert('User and Password is not correct!')</script>");
             }

        }
    }
}