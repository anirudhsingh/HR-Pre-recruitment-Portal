using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Exam
{
    public partial class HR_Entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (MHRISesstion.CandidateId != null)
            //{
            //    Response.Redirect("CandidateLogin.aspx", false);
            //}
            //else
            //{

            //}
        }
        private void Add_data(string strname, string strlastname, string stremail,string strmobile, string strHRloginID)
        {
            
            string sql = string.Empty;
            SqlConnection conn = new SqlConnection(DataConstant.SqlConn);
            //SqlConnection conn = new SqlConnection(@"Data Source=MOG-PC27111;database=MHRIL;User id=sa;Password=satyam123$;");
            
            sql = "insert into MHRL_Hr_Candidate_Details(Firstname,Lastname,Emailid,mobileno,LoginID,createddate) values ('" + strname.ToString() + "','" + strlastname.ToString() + "','" + stremail.ToString() + "','" + strmobile.ToString() + "','" + strHRloginID.ToString() + "',getdate())";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text="Record Inserted";
                ClearTextBoxes();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text=msg;
            }
            finally
            {
                conn.Close();
            }

        }

        private bool IsExistData(string strname, string strLastname, string stremail, string strmobile, string strHRloginID)
        {
            string sql = string.Empty;
            SqlConnection conn = new SqlConnection(DataConstant.SqlConn);
            //SqlConnection conn = new SqlConnection(@"Data Source=MOG-PC27111;database=MHRIL;User id=sa;Password=satyam123$;");
            conn.Open();
            SqlCommand thisCommand = conn.CreateCommand();
            thisCommand.CommandText = "Select * from MHRL_Hr_Candidate_Details where Firstname='" + strname.ToString() + "' and LastName='" + strLastname.ToString() + "'  and Emailid='" + stremail.ToString() + "' and mobileno='" + strmobile.ToString() + "'";
            SqlDataReader thisReader = thisCommand.ExecuteReader();
            if (thisReader.Read())
            {
                //Console.WriteLine("\t{0}\t{1}", thisReader["loginid"], thisReader["password"]);
                return true;
            }
            else
            {
                //Console.WriteLine("\t{0}\t{1}", thisReader["loginid"], thisReader["password"]);
                return false;
            }
            thisReader.Close();
            conn.Close();
        }

        private void ClearTextBoxes()
        {
            txtCDFname.Text="";
            txtCDmobile.Text="";
            txtCDemail.Text="";
            txtlastname.Text = "";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string strHRLoginID = Request.QueryString["LoginID"];
            

            if (IsExistData(txtCDFname.Text,txtlastname.Text ,txtCDemail.Text, txtCDmobile.Text, strHRLoginID.ToString()))
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Record already exists cannot Insert.....";
            }
            else
            {
                Add_data(txtCDFname.Text,txtlastname.Text, txtCDemail.Text, txtCDmobile.Text, strHRLoginID.ToString());
                ClearTextBoxes();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           // Response.Redirect("CandidateLogin.aspx", false);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           

                Response.Redirect("CandidateLogin.aspx", false);
           
        }

        protected void tmrTimer_Tick(object sender, EventArgs e)
        {
            //Label1.Text = Convert.ToString(((tmrTimer.Interval) / 1000) / 60);
        }

    }

}