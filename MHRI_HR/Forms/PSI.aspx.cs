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

namespace Exam
{
    public partial class PSI : System.Web.UI.Page
    {
        static DataTable OldTable;
        static string PreviousrowQuesno = string.Empty;
        static string strPSIRange;
        static string strPreviousQuesAns;
        static int GridviewCurrentPageIndex;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess objGetRSIquestionList = new DataAccess();
            DataSet ds = new DataSet();
            Session["Candidateid"] = MHRISesstion.CandidateId;
            // Session["Candidateid"] = "2";
            if (!IsPostBack)
            {
                DataAccess DE = new DataAccess();
                List<DataEntity> lstCandidateDetails = DE.GetCandidateDetails(Convert.ToInt32(MHRISesstion.CandidateId), System.DateTime.Now.ToString("dd/MM/yyyy"));

                if (lstCandidateDetails.Count > 0)
                {                    
                    lblCandidateDetails.Text = "Welcome " + lstCandidateDetails[0].FirstNameTodisplayExampage;
                }
                
                ds = objGetRSIquestionList.GetListofQuestions("PSI");
                Session["ResultData"] = ds.Tables["QuesInfo"];
                GridView1.DataSource = ds.Tables["QuesInfo"];
                GridView1.DataBind();
                               
                CreateOldTable(OldTable);
                CopyDataOldTable((DataTable)Session["ResultData"]);
                strPSIRange = DataConstant.PSIRange;
            }

            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "";
        }

        private void CreateOldTable(DataTable dt1)
        {
            OldTable = new DataTable();
            OldTable.Columns.Add(new DataColumn("ID", typeof(string)));
            OldTable.Columns.Add(new DataColumn("QuestionNo", typeof(string)));
            OldTable.Columns.Add(new DataColumn("Grade", typeof(string)));
            OldTable.Columns.Add(new DataColumn("Question", typeof(string)));
            OldTable.Columns.Add(new DataColumn("QuestionGrade", typeof(string)));
        }

        private void CopyDataOldTable(DataTable dt1)
        {
            bool flg = false;
            int i, j;
            //if (OldTable.Rows.Count > 0)
            //{
            for (i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                flg = false;
                for (j = 0; j <= OldTable.Rows.Count - 1; j++)
                {
                    if (dt1.Rows[i]["ID"] == OldTable.Rows[j]["ID"])
                    {
                        OldTable.Rows[j]["Grade"] = dt1.Rows[i]["Grade"].ToString();
                        flg = true;
                    }
                }
                if (flg == false)
                {
                    DataRow dr = OldTable.NewRow();
                    dr[0] = dt1.Rows[i]["ID"].ToString();
                    dr[1] = dt1.Rows[i]["QuestionNo"].ToString();
                    dr[2] = dt1.Rows[i]["Grade"].ToString();
                    dr[3] = dt1.Rows[i]["Question"].ToString();
                    dr[4] = dt1.Rows[i]["QuestionGrade"].ToString();
                    OldTable.Rows.Add(dr);
                }
            }
            //} 
        }
               

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt16(e.Row.Cells[0].Text) % 2 == 1)
                {
                    e.Row.Enabled = true;
                }
                else
                {
                    e.Row.Enabled = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt16(e.Row.Cells[1].Text) % 2 > 0)
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#f1f1f1");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (PreviousrowQuesno == e.Row.Cells[1].Text)
                {
                    e.Row.Cells[0].RowSpan = 2;
                }
                PreviousrowQuesno = e.Row.Cells[1].Text;
            }
        }

       
        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                int i = 1;
                //for (int i = 0; i < row.Cells.Count; i++)
                //{
                if (row.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                           previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
                //}
            }
        }
        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewCurrentPageIndex = GridView1.PageIndex;

            if (e.NewPageIndex > GridviewCurrentPageIndex)
            {
                EnableSubmit();

                if (AreAllQuesInthispageDone() && AreAllQuesInthispagehasNoChar() && AreAllValidDigits())
                {
                    RememberOldValues();

                    GridView1.DataSource = OldTable;
                    //if (AreValidateSumForSelected(OldTable))
                    //{
                        GridView1.PageIndex = e.NewPageIndex;
                        GridView1.DataBind();

                        TextBox temptxt = (TextBox)this.GridView1.Rows[0].FindControl("TextBox2");
                        temptxt.Focus();
                    //}
                    //else
                    //{
                    //    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //    //lblmsg.Text = "!!!!! Pair sum should be " + strRSIRange.ToString() + " !!!!!";
                    //    lblmsg.Text = "Please enter valid digit i.e. (0,1,2,3,4,5)";
                    //}
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //lblmsg.Text = "!!!!! Pair sum should be " + strRSIRange.ToString() + " !!!!!";
                    lblmsg.Text = "Please enter valid digit i.e. (0,1,2,3,4,5). All questions are mandetory";
                }
            }
            else
            {

                lblmsg.Text = "";
                RememberOldValues();

                GridView1.DataSource = OldTable;
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
        }

        private bool AreAllValidDigits()
        {
            int intPSIRange = Convert.ToInt16(strPSIRange.ToString());
            bool result = true;
            BGColor();
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox txt = (TextBox)row.FindControl("Textbox2");
                if (txt.Text.ToString().Trim().Length <= 0)
                {
                    txt.BorderStyle = BorderStyle.NotSet;
                    txt.BorderColor = System.Drawing.Color.Red;
                    TextboxSetFocus(row.RowIndex);
                    result = false;
                }
                else if (!(Convert.ToInt16(txt.Text.ToString()) >= 0 && Convert.ToInt16(txt.Text.ToString()) <= intPSIRange))
                {
                    txt.BorderStyle = BorderStyle.NotSet;
                    txt.BorderColor = System.Drawing.Color.Red;
                    TextboxSetFocus(row.RowIndex);
                    result = false;
                }
            }
            return result;
        }

        private bool AreAllQuesInthispagehasNoChar()
        {
            bool result = true;
            BGColor();
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox txt = (TextBox)row.FindControl("Textbox2");
                if (txt.Text.ToString().Trim().Length <= 0)
                {
                    txt.BorderStyle = BorderStyle.NotSet;
                    txt.BorderColor = System.Drawing.Color.Red;
                    TextboxSetFocus(row.RowIndex);
                    result = false;
                }
                else if (!(txt.Text.ToString()).All(Char.IsDigit))
                {
                    txt.BorderStyle = BorderStyle.NotSet;
                    txt.BorderColor = System.Drawing.Color.Red;
                    TextboxSetFocus(row.RowIndex);
                    result = false;
                }
            }
            return result;
        }


        private bool AreAllQuesInthispageDone()
        {
            bool result = true;
            GridViewRow previousrow;
            BGColor();
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox txt = (TextBox)row.FindControl("Textbox2");
                if (Convert.ToInt16(row.Cells[1].Text) % 2 > 0)
                {

                    row.BackColor = System.Drawing.Color.FromName("#f1f1f1");
                }
                else
                {

                    row.BackColor = System.Drawing.Color.White;
                }
                if (Convert.ToInt16(row.Cells[0].Text) % 2 == 1)
                {
                    if (txt.Text.ToString().Trim().Length <= 0)
                    {
                        txt.BorderStyle = BorderStyle.NotSet;
                        txt.BorderColor = System.Drawing.Color.Red;
                        result = false;
                    }
                }
                else
                {
                    previousrow = GridView1.Rows[row.RowIndex - 1];
                    TextBox previoustxt = (TextBox)previousrow.FindControl("Textbox2");
                    if (txt.Text.ToString().Trim().Length <= 0)
                    {
                        txt.BorderStyle = BorderStyle.NotSet;
                        txt.BorderColor = System.Drawing.Color.Red;
                        previoustxt.BorderStyle = BorderStyle.NotSet;
                        previoustxt.BorderColor = System.Drawing.Color.Red;
                        result = false;
                    }
                }

                //
                //if (txt.Text.ToString().Trim().Length <= 0)
                //{
                //    txt.BorderStyle = BorderStyle.NotSet;
                //    txt.BorderColor = System.Drawing.Color.Red;
                //    //if (row.RowIndex > 0)
                //    //{
                //    //    TextboxSetFocus(row.RowIndex - 1);
                //    //}
                //    result = false;
                //}
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox txt = (TextBox)row.FindControl("Textbox2");
                if (txt.Text.ToString().Trim().Length <= 0)
                {
                    TextboxSetFocus(row.RowIndex);
                    break;
                }
            }
            return result;
        }

        private void RememberOldValues()
        {
            int j;
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox txt = (TextBox)row.FindControl("Textbox2");

                for (j = 0; j <= OldTable.Rows.Count - 1; j++)
                {
                    if (row.Cells[0].Text.Trim() == OldTable.Rows[j]["ID"].ToString().Trim() && row.Cells[1].Text.Trim() == OldTable.Rows[j]["QuestionNo"].ToString().Trim() && row.Cells[4].Text.Trim() == OldTable.Rows[j]["QuestionGrade"].ToString().Trim())
                    {
                        OldTable.Rows[j]["Grade"] = txt.Text;
                    }
                }
            }
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            GridView1.Columns[0].Visible = true;
            GridView1.Columns[4].Visible = true;
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridView1.Columns[0].Visible = false;
            GridView1.Columns[4].Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        public bool AreAllQuestionDone(DataTable dt)
        {
            int j;
            try
            {
                for (j = 0; j <= dt.Rows.Count - 1; j++)
                {
                    string strgrade = dt.Rows[j]["Grade"].ToString();
                    int temp = Convert.ToInt16(strgrade);
                }
                return true;
            }
            catch (Exception e)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                //lblmsg.Text = "Please Complete the Test....before that cannot Submit.......";
                return false;
            }
        }


        public bool AreValidateSumForSelected(DataTable dt)
        {
            int intRSIRange = Convert.ToInt16(strPSIRange.ToString());

            bool flg = true;
            Dictionary<string, int> dicSum = new Dictionary<string, int>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    string group = row["QuestionNo"].ToString();
                    if (row["Grade"].Equals(String.Empty))
                    {

                    }
                    else
                    {
                        int rate = Convert.ToInt32(row["Grade"]);
                        if (dicSum.ContainsKey(group))
                            dicSum[group] += rate;
                        else
                            dicSum.Add(group, rate);
                    }
                }
                foreach (string g in dicSum.Keys)
                {
                    if (dicSum[g] == intRSIRange)
                    {

                    }
                    else
                    {
                        flg = false;
                    }
                }
                //Console.WriteLine("SUM({0})={1}", g, dicSum[g]);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message.ToString();
            }

            return flg;
        }

        public bool AreValidateSum(DataTable dt)
        {
            int intPSIRange = Convert.ToInt16(strPSIRange.ToString());

            bool flg = true;
            Dictionary<string, int> dicSum = new Dictionary<string, int>();
            foreach (DataRow row in dt.Rows)
            {
                string group = row["QuestionNo"].ToString();
                int rate = Convert.ToInt32(row["Grade"]);
                if (dicSum.ContainsKey(group))
                    dicSum[group] += rate;
                else
                    dicSum.Add(group, rate);
            }
            foreach (string g in dicSum.Keys)
            {
                if (dicSum[g] == intPSIRange)
                {

                }
                else
                {
                    flg = false;
                }
            }           
            return flg;
        }

              
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            MergeRows(GridView1);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;
            try
            {
                string str = ((TextBox)sender).Text;
                int i;
                if (str != null && (str.Trim()).Length > 0)
                {
                    i = Convert.ToInt16(strPSIRange.ToString()) - Convert.ToInt16(str.ToString());
                    if (i < 0)
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        //lblmsg.Text = "!!!!! Pair sum should be " + strPSIRange.ToString() + " !!!!!";
                        TextboxSetFocus(rowindex);
                        lblmsg.Text = "Please enter valid digit i.e. (0,1,2,3,4,5)";
                    }
                    else
                    {
                        strPreviousQuesAns = i.ToString();
                        if (Convert.ToInt16(this.GridView1.Rows[rowindex].Cells[0].Text) % 2 == 1)
                        {
                            if (strPreviousQuesAns != null)
                            {
                                TextBox txtresult = (TextBox)this.GridView1.Rows[rowindex + 1].FindControl("Textbox2");
                                txtresult.Text = strPreviousQuesAns.ToString();

                                tb.BorderStyle = BorderStyle.NotSet;
                                txtresult.BorderStyle = BorderStyle.NotSet;
                                tb.BorderColor = System.Drawing.Color.FromName("#DFDFDF");
                                txtresult.BorderColor = System.Drawing.Color.FromName("#DFDFDF");  //System.Drawing.Color.Gray;

                                RememberOldValues();
                                if (GridView1.Rows.Count > 2 && (rowindex + 2) < this.GridView1.PageSize)
                                {
                                    TextboxSetFocus(rowindex + 2);
                                }
                            }
                        }
                        lblmsg.Text = "";
                    }


                    #region Row Background Colour
                    BGColor();


                    #endregion  Row Background Colour



                    if (this.GridView1.PageIndex == Convert.ToInt16(DataConstant.PSInoofPages.ToString()))
                    {
                        EnableSubmit();
                    }
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    TextboxSetFocus(rowindex);
                    lblmsg.Text = "Cannot be null or empty..........";
                }

            }
            catch (Exception ee)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                TextboxSetFocus(rowindex);
                lblmsg.Text = "Please enter valid digit i.e. (0,1,2,3,4,5)";
            }
        }
        private void EnableSubmit()
        {
            if (AreAllQuestionDone(OldTable))
            {
                ImageButton1.Visible = true;
            }
            else
            {
                ImageButton1.Visible = false;
            }
        }
        private void TextboxSetFocus(int intRow)
        {
            TextBox txt = (TextBox)this.GridView1.Rows[intRow].FindControl("Textbox2");
            txt.Focus();
        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            DataAccess objSaveData = new DataAccess();
            RememberOldValues();
            if (AreAllQuestionDone(OldTable))
            {
                if (AreValidateSum(OldTable))
                {
                    //SaveUpdateRecords(OldTable);
                    if (objSaveData.SaveUpdateRecords("PSI", Session["Candidateid"].ToString(), OldTable))
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Text = "Record saved sucessfully";
                        Response.Redirect("../Forms/Thankyou.aspx", false);
                    }
                    else
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Error while saving data";
                    }                            
                }
                else
                {
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    //lblmsg.Text = "!!!!! Pair sum should be " + strPSIRange.ToString() + " !!!!!";
                    lblmsg.Text = "Please enter valid digit i.e. (0,1,2,3,4,5)";
                }
            }
        }

        public void BGColor()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (Convert.ToInt16(row.Cells[1].Text) % 2 > 0)
                {

                    row.BackColor = System.Drawing.Color.FromName("#f1f1f1");
                }
                else
                {

                    row.BackColor = System.Drawing.Color.White;
                }



            }
        }
        
    }
}
