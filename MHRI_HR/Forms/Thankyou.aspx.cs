using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
    public partial class Thankyou : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TimerToReloadHRpage.Enabled = true;
                SendMail();
                lblerror.Visible = true;
                lblerror.ForeColor = System.Drawing.Color.FromName("#0D9DDB");
                lblerror.Text = "You will be redirected to HR Login page in 20 secs";
            }

            //try
            //{
            //    SendMail SS = new SendMail();
            //   // MHRISesstion.CandidateId = "187";
            //    //MHRISesstion.HREmailid = "Rupali.Ladge@techmahindra.com";
            //    //MHRISesstion.HREmailid = "Sandeep.Verma1@techmahindra.com";
            //    //MHRISesstion.HREmailid = "hariprasanth.br@mahindraholidays.com";
            //    SS.SendEmail(Convert.ToInt32(MHRISesstion.CandidateId), System.DateTime.Now.ToString("dd/MM/yyyy"));
            //}

            //catch (Exception ex)
            //{
            //   lblerror.Visible = true;

            //   lblerror.Text = Convert.ToString(ex.Message);
            //    throw ex;
            //}




            //call the mailer here
        }

        protected void TimerToReloadHRpage_Tick(object sender, EventArgs e)
        {
            TimerToReloadHRpage.Enabled = false;
            RedirectToMainPage();
        }

        public void SendMail()
        {
            try
            {
                SendMail SS = new SendMail();
                // MHRISesstion.CandidateId = "187";
                //MHRISesstion.HREmailid = "Rupali.Ladge@techmahindra.com";
                //MHRISesstion.HREmailid = "Sandeep.Verma1@techmahindra.com";
                //MHRISesstion.HREmailid = "hariprasanth.br@mahindraholidays.com";
                SS.SendEmail(Convert.ToInt32(MHRISesstion.CandidateId), System.DateTime.Now.ToString("dd/MM/yyyy"));
            }

            catch (Exception ex)
            {
                lblerror.Visible = true;

                lblerror.Text = Convert.ToString(ex.Message);
                throw ex;
            }
        }
        public void RedirectToMainPage()
        {
            MHRISesstion.CandidateId = null;
            MHRISesstion.HRCandidateFirstName = null;
            MHRISesstion.HREmailid = null;
            MHRISesstion.CandidateCAFduration = null;
            Response.Redirect("HR_Login.aspx", true);
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //RedirectToMainPage();
        }
    }
}
