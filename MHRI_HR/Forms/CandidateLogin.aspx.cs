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
using System.Collections.Generic;


namespace Exam
{
    public partial class HRLogin : System.Web.UI.Page
    {
        #region PageLoadEvent

        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                try
                {
                    txtfirstname.Focus();
                    txtyear.ForeColor = System.Drawing.Color.Gray;
                    #region  BindDropdown
                    BindLocation();
                    BindPosition();
                    BindQualification();
                    BindExperience();
                    chkdeclaration.Checked = false;
                    //BtnLogin.Enabled = false;
                    lblErrorMessage.Text = "";
                    #endregion
                }

                catch (Exception ex)
                {
                    throw ex;
                }


            }
            //else
            //{
            //    if (chkdeclaration.Checked == true)
            //    {
            //        BtnLogin.Enabled = true;
            //        lblErrorMessage.Text = "";                    
            //    }
            //    else
            //    {
            //        BtnLogin.Enabled = false;                    
            //        lblErrorMessage.Text = "Please accept the declaration.";
            //    }
            //}
        }

     


        #endregion


        #region Fill Dropdowm
        public void BindLocation()
        {
            try
            {
                List<DataEntity> lstLocation = new List<DataEntity>();
                DataAccess objda = new DataAccess();
                lstLocation = objda.GetAlllocation();

                if (lstLocation.Count > 0)
                {

                    ddllocation.DataValueField = "LocationId";
                    ddllocation.DataTextField = "LocationName";
                    ddllocation.DataSource = lstLocation;
                    ddllocation.DataBind();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void BindPosition()
        {
            try
            {
                List<DataEntity> lstPosition = new List<DataEntity>();
                DataAccess objda = new DataAccess();
                lstPosition = objda.GetAllPosition();

                if (lstPosition.Count > 0)
                {

                    ddlposition.DataValueField = "PositionId";
                    ddlposition.DataTextField = "Position";
                    ddlposition.DataSource = lstPosition;
                    ddlposition.DataBind();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindQualification()
        {
            try
            {
                List<DataEntity> lstQualification = new List<DataEntity>();
                DataAccess objda = new DataAccess();
                lstQualification = objda.GetAllQualification();

                if (lstQualification.Count > 0)
                {

                    ddlQualification.DataValueField = "QualificationId";
                    ddlQualification.DataTextField = "Qualification";
                    ddlQualification.DataSource = lstQualification;
                    ddlQualification.DataBind();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void BindExperience()
        {
            try
            {
                List<DataEntity> lstExperience = new List<DataEntity>();
                DataAccess objda = new DataAccess();
                lstExperience = objda.GetAllExperience();

                if (lstExperience.Count > 0)
                {

                    ddlExpeience.DataValueField = "ExperienceId";
                    ddlExpeience.DataTextField = "Experience";
                    ddlExpeience.DataSource = lstExperience;
                    ddlExpeience.DataBind();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion


        #region Button Event
        protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                bool IsvalidMobile, IsvalidEmial, IsvalidPAN;
                IsvalidMobile = ValidateMobileControl();
                IsvalidEmial = ValidateEmailControl();
                IsvalidPAN = ValidatePANControl();

                if (IsvalidMobile && IsvalidEmial && IsvalidPAN)
                {


                    Boolean Flag;
                    Flag = false;
                    DataAccess AuthenCandidate = new DataAccess();
                    DataEntity DE = new DataEntity();
                    DE.FirstName = txtfirstname.Text;
                    DE.LastName = txtlastname.Text;
                    DE.MobileNo = txtmobile.Text;
                    DE.EmailId = txtEmail.Text;

                    //Flag = AuthenCandidate.AuthencateCandidate(DE);

                    Flag = true;
                    if (Flag == true)
                    {
                        DE.LocationID = Convert.ToInt32(ddllocation.SelectedValue);
                        DE.PositionID = Convert.ToInt32(ddlposition.SelectedValue);
                        DE.QualificationId = Convert.ToInt32(ddlQualification.SelectedValue);
                        DE.ExperienceId = Convert.ToInt32(ddlExpeience.SelectedValue);
                        DE.Day = ddlday.SelectedItem.Text;
                        DE.Month = ddldobmonth.SelectedItem.Text;
                        DE.Year = txtyear.Text;
                        if (chkdeclaration.Checked == true)
                        {
                            DE.AcceptDec = 1;
                        }
                        else
                        {
                            DE.AcceptDec = 0;
                        }

                        DE.PanNo = txtpanno.Text;
                                               

                        if (vadidateDOB(DE.Day, DE.Month, DE.Year))
                        {
                            if (chkdeclaration.Checked == true)
                            {
                                //Int32 can = AuthenCandidate.InsertCandidateDetails(DE);
                                MHRISesstion.CandidateId = Convert.ToString(AuthenCandidate.InsertCandidateDetails(DE));
                                MHRISesstion.HRCandidateFirstName = txtfirstname.Text;
                                //MHRISesstion.TimeLeftofCAFTest = null;
                                Session["TimeLeftofCAFTest"] = null;
                                Response.Redirect("../Forms/CAF.aspx", false);
                            }
                            else
                            {
                                lblErrorMessage.Visible = true;
                                lblErrorMessage.Text = "Please accept the declaration.";

                            }
                        }

                        else
                        {
                            lblErrorMessage.Visible = true;
                            lblErrorMessage.Text = "DOB Not Proper Format And Year Should be >=1753 !!!!";
                        }
                        
                    }
                    else
                    {
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "You Are Not Authorised,Please Contact HR !!!!";

                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        #region TextBox Event

        protected void txtyear_TextChanged(object sender, EventArgs e)
        {
            txtyear.ForeColor = System.Drawing.Color.Black;
        }
        #endregion

        #region Mathod
        private bool ValidateEmailControl()
        {
            bool bolvalidate = false;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (txtEmail.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text.ToString().Trim()))
                {
                    txtEmail.BorderColor = System.Drawing.Color.Red;
                    bolvalidate = false;
                }
                else
                {
                    txtEmail.BorderColor = System.Drawing.Color.FromName("#CCCCCC");
                    bolvalidate = true;
                }
            }
            return bolvalidate;
        }
        private bool ValidatePANControl()
        {
            bool bolvalidate = false;
            System.Text.RegularExpressions.Regex rPAN = new System.Text.RegularExpressions.Regex(@"^[a-z|A-Z|]+[a-z|A-Z|0-9]*");
            if (txtpanno.Text.Length > 0)
            {
                if (!rPAN.IsMatch(txtpanno.Text.ToString().Trim()))
                {
                    txtpanno.BorderColor = System.Drawing.Color.Red;
                    bolvalidate = false;
                }
                else
                {
                    txtpanno.BorderColor = System.Drawing.Color.FromName("#CCCCCC");
                    bolvalidate = true;
                }
            }
            return bolvalidate;
        }

        private bool ValidateMobileControl()
        {
            bool bolvalidate = false;
            System.Text.RegularExpressions.Regex rMobile = new System.Text.RegularExpressions.Regex(@"\d{10}");

            if (txtmobile.Text.Length > 0)
            {
                if (!rMobile.IsMatch(txtmobile.Text.ToString().Trim()))
                {
                    txtmobile.BorderColor = System.Drawing.Color.Red;
                    bolvalidate = false;
                }
                else
                {
                    txtmobile.BorderColor = System.Drawing.Color.FromName("#CCCCCC");
                    bolvalidate = true;
                }
            }

            return bolvalidate;
        }


        public Boolean vadidateDOB(string day, string mon, string year)
        {
            Boolean val;
            val = true;

            try
            {
                if (Convert.ToInt32(year) < 1753)
                {
                    return val = false;

                }

                string dob = (day + "/" + mon + "/" + year);


                // DateTime dd = Convert.ToDateTime(Convert.ToDateTime(dob).ToString("dd/MM/yyyy"));

                DateTime dd = DateTime.ParseExact(dob, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                val = false;

            }

            return val;
        }
        #endregion
    }
}
