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
using System.Collections.Generic;
using System.Drawing;
namespace Exam
{
    public partial class HR : System.Web.UI.Page
    {


        #region PageLoad event

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                
                txtHRid.Focus();
                //txtHRpwd.TextMode = TextBoxMode.Password;
            }
                    
        }

        #endregion
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        #region Button Event
        protected void HRloginButton_Click(object sender, ImageClickEventArgs e)
        {
            DataAccess IsValidLoginbool = new DataAccess();

            if (IsValidLoginbool.IsValidLogin(txtHRid.Text, txtHRpwd.Text))
            {
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Sucessfull login";        
                Response.Redirect("../Forms/CandidateLogin.aspx",false);
            }
            else
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Invalid User";
            }

        }
        #endregion

    }
}
