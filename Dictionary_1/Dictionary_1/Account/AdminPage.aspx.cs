using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

 
namespace Dictionary_1.Account
{
    
    public partial class AdminPage : Page
    {
        public SqlConnection Conn = new SqlConnection("Data Source=MAITRANG;Initial Catalog=TuDien;Integrated Security=True");
       // bool flag = false;
        string _temp;
        int search = 0;
        static int editCount = 0;
        //int tempFind = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSearch1_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand textCom = new SqlCommand("select count(*) from SynTable where [word] like N'" + TextBoxFindword.Text + "' ", Conn);
       
            int wFind = Convert.ToInt32(textCom.ExecuteScalar().ToString());
            Conn.Close();
            if (wFind != 0)
            {
                TextBoxW.Text = TextBoxFindword.Text;
                // fill synonyms 
                Conn.Open();
                SqlCommand synCom = new SqlCommand("select synonyms from SynTable where word like N'" + TextBoxFindword.Text + "' ", Conn);
                string synText = synCom.ExecuteScalar().ToString().Replace(" ", "");
                TextBoxSyn.Text = synText;
                Conn.Close();

                // fill russian mean
                Conn.Open();
                SqlCommand rusCom = new SqlCommand("select rus_mean from SynTable where word like N'" + TextBoxFindword.Text + "' ", Conn);
                string rusText = rusCom.ExecuteScalar().ToString().Replace(" ", "");
                TextBoxRus.Text = rusText;
                Conn.Close();
                search++;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Not found synonyms!')</script>");
                TextBoxW.Text = "";
                TextBoxSyn.Text = "";
                TextBoxRus.Text = "";
            }
            TextBoxW.Enabled = false;
            TextBoxSyn.Enabled = false;
            TextBoxRus.Enabled = false;
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
           // flag = true;
            TextBoxW.Enabled = true;
            TextBoxSyn.Enabled = true;
            TextBoxRus.Enabled = true;
            editCount +=1;
            
        }
        /*-
        * Button Add data into Database
        */
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand textCom = new SqlCommand("select count(*) from SynTable where [word]=N'" + TextBoxW.Text + "' ", Conn);
            int tempF = Convert.ToInt32(textCom.ExecuteScalar().ToString().Replace(" ", ""));
            Conn.Close();
            if (tempF != 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Word was existed. You can not add it')</script>");
                return;
            }

            if (editCount == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Do you insert new word into text boxs?')</script>");
                return;
            }

            if ( TextBoxRus.Text != "" && TextBoxSyn.Text != "" && TextBoxW.Text != "")
            {
                //var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                
                SqlCommand cmd = new SqlCommand("insert into SynTable(word,synonyms,rus_mean) values(@word,@synonyms,@rus_mean)", Conn);
               

                cmd.Parameters.AddWithValue("@word", TextBoxW.Text);
                cmd.Parameters.AddWithValue("@synonyms", TextBoxSyn.Text);
                cmd.Parameters.AddWithValue("@rus_mean", TextBoxRus.Text);

                // msg.Text = "The data was inserted into database";
                try
                {
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script LANGUAGE='JavaScript' >alert('The values were inserted into database!')</script>");
                    TextBoxW.Enabled = false;
                    TextBoxSyn.Enabled = false;
                    TextBoxRus.Enabled = false;
                }
                catch
                {
                    //msg.Text = ex.Message.ToString();
                    Response.Write("<script LANGUAGE='JavaScript' >alert('The values were not inserted into database!')</script>");
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please insert word, synonyms or meaning!')</script>");
            }
        }

        /*-
         * Button Update data into Database
         */
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
           
            if (TextBoxRus.Text != "" && TextBoxSyn.Text != "" && TextBoxW.Text != "")
            {
                if (editCount == 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Do you edit anything into text boxs?')</script>");
                    return;
                }
                //var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                // find word was existed.
                Conn.Open();
                SqlCommand textCom = new SqlCommand("select count(*) from SynTable where [word]=N'" + TextBoxW.Text + "' ", Conn);
                int tempF = Convert.ToInt32(textCom.ExecuteScalar().ToString().Replace(" ", ""));
                Conn.Close();
                if (tempF == 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Word was not exsited! Can not Update into Database!')</script>");
                   // string script = "<script type=\"text/javascript\">alert('Word wasn't exsited! Can't Update into Database.');</script>";
                   // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script);
                    return;
                }

                SqlCommand cmd = new SqlCommand("update SynTable set word=@word,synonyms=@synonyms,rus_mean=@rus_mean WHERE [word]=@word", Conn);
                
                cmd.Parameters.AddWithValue("@word", TextBoxW.Text);
                cmd.Parameters.AddWithValue("@synonyms", TextBoxSyn.Text);
                cmd.Parameters.AddWithValue("@rus_mean", TextBoxRus.Text);

                // msg.Text = "The data was inserted into database";
                try
                {
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script LANGUAGE='JavaScript' >alert('The values were Updated into database!')</script>");
                    TextBoxW.Enabled = false;
                    TextBoxSyn.Enabled = false;
                    TextBoxRus.Enabled = false;
                }
                catch
                {
                    //msg.Text = ex.Message.ToString();
                    Response.Write("<script LANGUAGE='JavaScript' >alert('The values were not Updated into database!')</script>");
                }
                finally
                {
                    Conn.Close();
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please insert word, synonyms or meaning!')</script>");
            }
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {

            
            if (TextBoxFindword.Text != "" && search !=0)
            {
                _temp = TextBoxFindword.Text;

            }
            else
            {
                if (TextBoxW.Text != "")
                {
                    _temp = TextBoxW.Text;
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please insert word which need to Delete from Database!')</script>");
                    return;
                }
            }
                try
                {
                    Conn.Open();
                    SqlCommand deleteCmd = new SqlCommand("delete FROM SynTable where [word]=N'" + _temp + "' ", Conn);
                    int k = deleteCmd.ExecuteNonQuery();
                    TextBoxW.Enabled = false;
                    TextBoxSyn.Enabled = false;
                    TextBoxRus.Enabled = false;
                    if (k != 0)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Word was deleted!')</script>");
                        TextBoxW.Text = "";
                        TextBoxRus.Text = "";
                        TextBoxSyn.Text = "";
                        TextBoxFindword.Text = "";
                    }
                    else
                    {
                       // Response.Write("<script LANGUAGE='JavaScript' >alert('Word wasn't existed into Database!')</script>");
                       // return;
                        Response.Write("<script>alert('Word was not existed into DB')</script>");
                    }

                }
              //  catch
               // {
              //      Response.Write("<script LANGUAGE='JavaScript' >alert('Word wasn't existed into Database!')</script>");
               // }
                finally
                {
                    Conn.Close();
                }
            
                        
            
        }
    }
}