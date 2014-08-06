using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
//using System.Data.



namespace Dictionary_1
{
    public partial class _Default : Page
    {
        public SqlConnection conn = new SqlConnection("Data Source=MAITRANG;Initial Catalog=TuDien;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
           // EnablePartialRendering = "false";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            
                // get word to search from textbox
            string _syn = TextBox1.Text;
            //Convert.ToChar(_syn);

                // connection to database
                SqlCommand com = new SqlCommand("select * from SynTable where [word] like N'"+_syn+"' ", conn);
          //  string com = "select * from SynTable where [word]='" + _syn + "' ";
                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {

                    TextBox2.Text = reader["synonyms"].ToString();
                    TextBox3.Text = reader["rus_mean"].ToString();
                    //reader.Close();

                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Not found synonyms!')</script>");
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
            conn.Close();
                
            
        }
    }
}