using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic; 
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
    public partial class CAF : System.Web.UI.Page
    {
       
        DataAccess DE = new DataAccess();
        public static List<DataEntity> Lst = new List<DataEntity>();
        

        #region PageLoadEvent             

        protected void Page_Load(object sender, EventArgs e)
        {
           //Page.SmartNavigation = true;
            

            Session["Candidateid"] = MHRISesstion.CandidateId;            
            //Session["Candidateid"] = "5";
            if (!Page.IsPostBack)
            {
                //Lst.Clear();

                TimeLeftForCAFTest.Enabled = true;
               
                if (Session["TimeLeftofCAFTest"] == null)
                //if (MHRISesstion.TimeLeftofCAFTest == null)
                {
                    DateTime start_time = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    DateTime end_time = start_time.AddMinutes(Convert.ToInt16(DataConstant.CAFTestDuration.ToString()));
                    lblTimeleft.Text = "Start time:" + System.DateTime.Now.ToString("HH:mm:ss tt") + " Time left:" + DataConstant.CAFTestDuration;
                    Session["TimeLeftofCAFTest"] = DateTime.Parse(end_time.ToString("MM/dd/yyyy hh:mm:ss tt"));                    
                    //MHRISesstion.TimeLeftofCAFTest = Session["Temp_TimeLeftofCAFTest"].ToString();
                }
                
              
                List<DataEntity> lstCandidateDetails = DE.GetCandidateDetails(Convert.ToInt32(MHRISesstion.CandidateId), System.DateTime.Now.ToString("dd/MM/yyyy"));

                if (lstCandidateDetails.Count > 0)
                {
                    
                    lblCandidateDetails.Text = "Welcome " + lstCandidateDetails[0].FirstNameTodisplayExampage;
                }

                if (Lst.Count == 0)
                {
                    Lst = new List<DataEntity>();
                    Lst = DE.GetCAFQuestion();
                }
                else
                {
                    if (string.IsNullOrEmpty(Convert.ToString(Session["TimeTakenforCAFTest"])))
                    {
                        Lst = new List<DataEntity>();
                        Lst = DE.GetCAFQuestion();
                    }
                }

                FillRepeater();
            }
        }
        #endregion

        #region RepeaterMathod

        protected void BindRepeaterData()
        {
            SqlConnection con = new SqlConnection(DataConstant.SqlConn);
            con.Open();

            //con.Open();
            SqlCommand cmd = new SqlCommand("select QNo,Q1,COALESCE(Q2,''),A1,A2,A3,A4,COALESCE(ImageURL,'') from CAF", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            con.Close();
        }

        public void FillRepeater()
        {
            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = Lst;

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = 1;

            //Disable Prev, Next buttons if necessary
            if (Lst.Count > 0)
            {
                if (Lst[0].QNo == 1)
                {
                    linkprev.Visible = false;
                    imgprev.Visible = false;
                    linknxt.Visible = true;
                    imgnxt.Visible = true;
                }

                else
                {
                    linkprev.Visible = true;
                    linknxt.Visible = true;
                    imgprev.Visible = true;
                    imgnxt.Visible = true;
                }

            }

            //lbtnPrev.Enabled = !objPds.IsFirstPage;
            //lbtnNext.Enabled = !objPds.IsLastPage;

            //Assign PagedDataSource to repeater
            Repeater1.DataSource = objPds;
            Repeater1.DataBind();

            if (Lst[0].strImageURL.Length > 0)
            {
                Lst[0].IsImageURL = true;
                //Image1.Visible = true;
                //Image1.ImageUrl = Lst[0].strImageURL;
            }
            else
            {
                Lst[0].IsImageURL = false;
                //Image1.ImageUrl = "";
                //Image1.Visible = false;
            }
        }

        private void CheckForAnswers()
        {

            //if (Repeater1.Items.Count > 0)
            //{
                //for (int count = 0; count < Repeater1.Items.Count; count++)
                //{

            //int presentrec= NowViewing - 1;

            RadioButton rd1 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton1");
            RadioButton rd2 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton2");
            RadioButton rd3 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton3");
            RadioButton rd4 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton4");
                    if (rd1.Checked)
                    {
                        var obj = Lst.FirstOrDefault(x => x.QNo == NowViewing);
                        if (obj != null)
                            obj.SelectedAns = 1;

                    }
                    if (rd2.Checked)
                    {
                        var obj = Lst.FirstOrDefault(x => x.QNo == NowViewing);
                        if (obj != null)
                            obj.SelectedAns = 2;
                    }
                    if (rd3.Checked)
                    {
                        var obj = Lst.FirstOrDefault(x => x.QNo == NowViewing);
                        if (obj != null)
                            obj.SelectedAns = 3;

                    }
                    if (rd4.Checked)
                    {
                        var obj = Lst.FirstOrDefault(x => x.QNo == NowViewing);
                        if (obj != null)
                            obj.SelectedAns = 4;
                    }
                //}
           // }

        }

        public void FillFilterRepeaterpre(List<DataEntity> objlst)
        {

            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = objlst;

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = 1;

            //Disable Prev, Next buttons if necessary
            //lbtnPrev.Enabled = !objPds.IsFirstPage;
            //lbtnNext.Enabled = !objPds.IsLastPage;
            if (Convert.ToInt32(objlst[0].QNo) == 1)
            {
                linkprev.Enabled = false;
                imgprev.Enabled = false;
            }

            if (Convert.ToInt32(objlst[0].QNo) < Lst.Count)
            {


                linknxt.Enabled = true;
                imgnxt.Enabled = true;
            }

            //Assign PagedDataSource to repeater
            Repeater1.DataSource = objPds;
            Repeater1.DataBind();

            if (objlst[0].strImageURL.Length > 0)
            {
                objlst[0].IsImageURL = true;
                //Image1.Visible = true;
                //Image1.ImageUrl = objlst[0].strImageURL;
            }
            else
            {
                objlst[0].IsImageURL = false;
                //Image1.ImageUrl = "";
                //Image1.Visible = false;
            }
            BindOptionButton(objlst[0]);

        }

        public void BindOptionButton(DataEntity X)
        {
            if (X.SelectedAns == 1)
            {
                RadioButton rd1 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton1");
                rd1.Checked = true;
            }
            else if (X.SelectedAns == 2)
            {
                RadioButton rd2 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton2");
                rd2.Checked = true;
            }
            else if (X.SelectedAns == 3)
            {
                RadioButton rd3 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton3");
                rd3.Checked = true;
            }
            else if (X.SelectedAns == 4)
            {
                RadioButton rd4 = (RadioButton)Repeater1.Items[0].FindControl("RadioButton4");
                rd4.Checked = true;
            }

        }

        private void SaveUpdateRecords(List<DataEntity> objSaveLst)
        {
            //string strQuery = string.Empty;
            //SqlConnection conn = new SqlConnection(DataConstant.SqlConn);

            //conn.Open();
           
            try
            {
                foreach (DataEntity de in objSaveLst)
                {
                    DataEntity InsertCAFAns=new DataEntity ();
                    InsertCAFAns.QNo = de.QNo;
                    InsertCAFAns.SelectedAns = de.SelectedAns;
                   
                    //strQuery = "IF NOT EXISTS(select * from dbo.MHRI_PSI_RSI_CAF_Scores where Candidateid=" + Session["Candidateid"] + " and Category='CAF' and QuesNo='" + de.QNo + "' and QuestionChar='X' and convert(date,Examdate,101)=convert(date,GETDATE(),101)) " +
                    //" Insert into MHRI_PSI_RSI_CAF_Scores values(" + Session["Candidateid"] + ",getdate(),'" + de.QNo + "','X','" + de.SelectedAns + "','CAF')" +
                    //" else " +
                    //" Update MHRI_PSI_RSI_CAF_Scores set value='" + de.SelectedAns + "' where Candidateid=" + Session["Candidateid"] + " and Category='CAF' and QuesNo='" + de.QNo + "' and QuestionChar='X' and convert(date,Examdate,101)=convert(date,GETDATE(),101)";

                    DE.InsertCAFAnswer(InsertCAFAns,Convert.ToInt32(Session["Candidateid"]));

                    //SqlCommand cmd = new SqlCommand(strQuery, conn);

                    //cmd.ExecuteNonQuery();
                    
                }

                lblmsg.Text = "Record saved sucessfully";                
            }
            catch (Exception ex)
            {                
                lblmsg.Text = ex.Message;
            }
            finally
            {
                //conn.Close();
            }

        }

        public void FillFilterRepeaternext(List<DataEntity> objlst)
        {
            if (objlst[0].strImageURL.Length > 0)
            {
                objlst[0].IsImageURL = true;
                
            }
            else
            {
                objlst[0].IsImageURL = false;
                
            }

            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = objlst;

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = 1;

            //Disable Prev, Next buttons if necessary
            // lbtnPrev.Enabled = !objPds.IsFirstPage;

            if (Convert.ToInt32(objlst[0].QNo) == Lst.Count)
            {

                linknxt.Enabled = false;
                imgnxt.Enabled = false;
                linkprev.Enabled = true;                
                imgprev.Enabled = true;
            }
            else
            {
                linknxt.Enabled = true;
                imgnxt.Enabled = true;
                linkprev.Enabled = true;                
                imgprev.Enabled = true;
            }

            //Assign PagedDataSource to repeater
            Repeater1.DataSource = objPds;
            Repeater1.DataBind();
            
            BindOptionButton(objlst[0]);
                        
        }

        public int NowViewing
        {
            get
            {


                object obj = ViewState["_NowViewing"];
                if (obj == null)
                    return 0;
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["_NowViewing"] = value;
            }
        }

        #endregion

        #region TimerEvent

        protected void TimeLeftForCAFTest_Tick(object sender, EventArgs e)
        {
            DateTime dt = (DateTime)Session["TimeLeftofCAFTest"];
            //DateTime dt_curr = DateTime.Now;
            DateTime dt_curr = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
            TimeSpan ts = dt - dt_curr;
            lblTimeleft.Text = "Time Left:" + ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            Session["TimeTakenforCAFTest"] = Convert.ToInt16(DataConstant.CAFTestDuration.ToString()) - Convert.ToInt16(ts.Minutes.ToString());
            MHRISesstion.CandidateCAFduration = Session["TimeTakenforCAFTest"].ToString();
            if (ts.Minutes == 0 && ts.Seconds == 0)
            {
                TimeLeftForCAFTest.Enabled = false;
                CheckForAnswers();            
                SaveUpdateRecords(Lst);
                Lst.Clear();
                Response.Redirect("RSI.aspx", false);
            }
        }

        #endregion

        #region ImageButtonEvent
        protected void BtnPrevious_Click1(object sender, EventArgs e)
        {
            List<DataEntity> lstfilter = new List<DataEntity>();
            CheckForAnswers();
            //Decrement page by one
            NowViewing = NowViewing - 1;
            //Fill repeater
            //FillRepeater();
            if (NowViewing < 0)
            {
                NowViewing = 0;
            }
            if (NowViewing == 0)
            {
                NowViewing = 1;
                lstfilter = Lst.Where(aa => aa.QNo == NowViewing).ToList();
            }

            else
            {
                lstfilter = Lst.Where(aa => aa.QNo == NowViewing).ToList();
            }

            if (lstfilter.Count > 0)
            {
                if (lstfilter[0].QNo == 1)
                {
                    linkprev.Visible = false;
                    imgprev.Visible = false;                    
                    linknxt.Visible = true;                     
                    imgnxt.Visible = 
                        true;
                }

                else
                {
                    linkprev.Visible = true;
                    imgprev.Visible = true;
					linknxt.Visible = true;
					imgnxt.Visible = true;
                }

            }

            if (NowViewing < 15)
            {
                LnkSubmit.Visible = false;
            }


            FillFilterRepeaterpre(lstfilter);

        }
        protected void BtnNext_Click1(object sender, EventArgs e)
        {
            if (NowViewing == 0)
                NowViewing = 1;
            CheckForAnswers();
            //Increment page by one
            if (NowViewing == 0)
            {
                NowViewing = NowViewing + 2;
            }

            else
            {
                NowViewing = NowViewing + 1;
            }
            //Fill repeater
            if (NowViewing > Lst.Count)
            {
                NowViewing = Lst.Count;
            }
            List<DataEntity> lstfilter = new List<DataEntity>();
            // lstfilter=lstfilter.IndexOf(0);

            lstfilter = Lst.Where(aa => aa.QNo == NowViewing).ToList();


            if (lstfilter.Count > 0)
            {
                if (lstfilter[0].QNo == 15)
                {
                    linkprev.Visible = true;
                    imgprev.Visible = true;
                    linknxt.Visible = false;
                    imgnxt.Visible = false;
                    
                }

                else
                {
                    linkprev.Visible = true;
                    imgprev.Visible = true;
                    linknxt.Visible = true;
                    imgnxt.Visible = true;
                }

            }



            FillFilterRepeaternext(lstfilter);

            if (NowViewing == 15)
            {
                LnkSubmit.Visible = true;
            }
            else
            {
                LnkSubmit.Visible = false;
            }
        }
        public void BtnSubmit_Click1(object sender, EventArgs e)
        {
            CheckForAnswers();            
            SaveUpdateRecords(Lst);
            Lst.Clear();
            Response.Redirect("../Forms/RSI.aspx", false);
        }
        #endregion



    }
   

}
