using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Exam
{
    public  class DataAccess
    {


        #region BindCandidatePageDropdown

        public  List<DataEntity> GetAlllocation()
        {
            try
            {
                SqlDataReader dr;
                List<DataEntity> lstLocation = new List<DataEntity>();

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetLocation", null);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    objlocation.LocationID = dr.GetInt32(0);
                    objlocation.LocationName = dr.GetString(1);
                    lstLocation.Add(objlocation);

                }


                return lstLocation;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<DataEntity> GetAllPosition()
        {
            try
            {
                SqlDataReader dr;
                List<DataEntity> lstPosition = new List<DataEntity>();

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetPosition", null);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    objlocation.PositionID = dr.GetInt32(0);
                    objlocation.Position = dr.GetString(1);
                    lstPosition.Add(objlocation);

                }


                return lstPosition;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<DataEntity> GetAllQualification()
        {
            try
            {

                SqlDataReader dr;
                List<DataEntity> lstQualification = new List<DataEntity>();

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetAllQualification", null);
                while (dr.Read())
                {
                    DataEntity objQualification = new DataEntity();
                    objQualification.QualificationId = dr.GetInt32(0);
                    objQualification.Qualification = dr.GetString(1);
                    lstQualification.Add(objQualification);

                }


                return lstQualification;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<DataEntity> GetAllExperience()
        {

            try
            {
                SqlDataReader dr;
                List<DataEntity> lstExperience = new List<DataEntity>();

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetAllExperience", null);
                while (dr.Read())
                {
                    DataEntity objExperience = new DataEntity();
                    objExperience.ExperienceId = dr.GetInt32(0);
                    objExperience.Experience = dr.GetString(1);
                    lstExperience.Add(objExperience);

                }


                return lstExperience;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion




        public Boolean AuthencateCandidate(DataEntity objCan)
        {
            try
            {

                Boolean CandidateFlag;
                CandidateFlag = false;

                SqlParameter[] param =
            {

                new SqlParameter ("@Fname",SqlDbType.NVarChar),
                new SqlParameter ("@Lname",SqlDbType.NVarChar),
                new SqlParameter ("@MobileNo",SqlDbType.NVarChar),
                new SqlParameter ("@EmailId",SqlDbType.NVarChar),
                
            };
                param[0].Value = objCan.FirstName;
                param[1].Value = objCan.LastName;
                param[2].Value = objCan.MobileNo;
                param[3].Value = objCan.EmailId;

                SqlDataReader dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "AuthenticateCandidate", param);

                while (dr.Read())
                {
                    if (dr.GetInt32(0) == 1)
                    {
                        CandidateFlag = true;
                    }

                }

                return CandidateFlag;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public Int32 InsertCandidateDetails(DataEntity objCan)
        {
            try
            {


                Int32 CandidateID;
                CandidateID = 0;

                SqlParameter[] param =
            {

                new SqlParameter ("@Fname",SqlDbType.NVarChar),
                new SqlParameter ("@Lname",SqlDbType.NVarChar),
                new SqlParameter ("@MobileNo",SqlDbType.NVarChar),
                new SqlParameter ("@EmailId",SqlDbType.NVarChar),
                 new SqlParameter ("@LocationId",SqlDbType.Int),
                new SqlParameter ("@PositionId",SqlDbType.Int),
                new SqlParameter ("@Day",SqlDbType.NVarChar),
                new SqlParameter ("@month",SqlDbType.NVarChar),
               new SqlParameter ("@year",SqlDbType.NVarChar),
                new SqlParameter ("@qualificationid",SqlDbType.Int),
                new SqlParameter ("@ExperinceId",SqlDbType.Int),
                 new SqlParameter ("@Accdec",SqlDbType.Bit),
                 new SqlParameter ("@panNo",SqlDbType.NVarChar)
            };
                param[0].Value = objCan.FirstName;
                param[1].Value = objCan.LastName;
                param[2].Value = objCan.MobileNo;
                param[3].Value = objCan.EmailId;

                param[4].Value = objCan.LocationID;
                param[5].Value = objCan.PositionID;
                param[6].Value = objCan.Day;
                param[7].Value = objCan.Month;
                param[8].Value = objCan.Year;
                param[9].Value = objCan.QualificationId;
                param[10].Value = objCan.ExperienceId;
                param[11].Value = objCan.AcceptDec;
                param[12].Value = objCan.PanNo;

                SqlDataReader dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "InsetCandidateDetails", param);

                while (dr.Read())
                {

                    CandidateID = dr.GetInt32(0);


                }

                return CandidateID;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public List<DataEntity>  GetQuestion (Int32 I,Int32 J,string cat)
        {
            try
            {

                List<DataEntity> lst = new List<DataEntity>(); 

            SqlParameter[] param =
            {

                new SqlParameter ("@FQuNo",SqlDbType.Int),
                new SqlParameter ("@TQuNo",SqlDbType.Int),
                new SqlParameter ("@Catgory",SqlDbType.NVarChar)
                
                
            };
                param[0].Value = I;
                param[1].Value =J;
                param[2].Value = cat;


                SqlDataReader dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetQuestion", param);

                while (dr.Read())
                {
                    DataEntity DE = new DataEntity();
                    DE.FQuNo = dr.GetInt32(0);
                    DE.QueGrade = dr.GetString(1);
                    DE.RuntimeQuestion = dr.GetString(2);
                    lst.Add(DE);
                }

                return lst;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<DataEntity> SetQuestionValue(Int32 I, Int32 J, string cat,Int32 CanId,string ExamDate)
        {
            try
            {

                List<DataEntity> lst = new List<DataEntity>();

                SqlParameter[] param =
            {

                new SqlParameter ("@FQuNo",SqlDbType.Int),
                new SqlParameter ("@TQuNo",SqlDbType.Int),
                new SqlParameter ("@Catgory",SqlDbType.NVarChar),
                 new SqlParameter ("@CandidateId",SqlDbType.Int),
                new SqlParameter ("@TDate",SqlDbType.NVarChar)
                
                
                
            };

                param[0].Value = I;
                param[1].Value = J;
                param[2].Value = cat;
                param[3].Value = CanId;
                param[4].Value = ExamDate;


                SqlDataReader dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "SetQuestionValue", param);

                while (dr.Read())
                {
                    DataEntity DE = new DataEntity();
                    DE.FQuNo = dr.GetInt32(0);
                    DE.Quvalue = dr.GetInt32(1);
                    DE.QueGrade = dr.GetString(2);
                    lst.Add(DE);
                }

                return lst;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public Int32 InsertScore(Int32 CanId, string ExamDate, Int32 QuNo,string QuescharA,string QuescharB,Int32 quesValA,Int32 QuesValB, string cat)
        {
            try
            {

                List<DataEntity> lst = new List<DataEntity>();

                SqlParameter[] param =
            {

                new SqlParameter ("@CandidateId",SqlDbType.Int),
                new SqlParameter ("@examDate",SqlDbType.NVarChar),
                new SqlParameter ("@Quno",SqlDbType.Int),
                 new SqlParameter ("@QuescharA",SqlDbType.NVarChar),
                new SqlParameter ("@QuescharB",SqlDbType.NVarChar),
                new SqlParameter ("@quesValA",SqlDbType.Int),
                 new SqlParameter ("@quesValB",SqlDbType.Int),
                new SqlParameter ("@Catgory",SqlDbType.NVarChar)
                
                
                
            };

                param[0].Value = CanId;
                param[1].Value = ExamDate;
                param[2].Value = QuNo;
                param[3].Value = QuescharA;
                param[4].Value = QuescharB;
                param[5].Value = quesValA;
                param[6].Value = QuesValB;
                param[7].Value = cat;



                int J = SqlHelper.ExecuteNonQuery(DataConstant.SqlConn, CommandType.StoredProcedure, "InsertUpdateScore", param);

                

                return J;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public List<DataEntity> GetCandidateDetails(Int32 CanId,string Pdate)
        {
            try
            {
                SqlDataReader dr;
                List<DataEntity> lstEmail = new List<DataEntity>();

                SqlParameter[] param ={

                         new  SqlParameter ("@canid",SqlDbType.Int),
                         new  SqlParameter ("@Examdate",SqlDbType.NVarChar)
                                      };


                param[0].Value = CanId;
                param[1].Value = Pdate;

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "Email_GetCandidateDetails", param);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    objlocation.FirstNameTodisplayExampage = dr.GetString(0);
                    objlocation.FirstName = dr.GetString(1);
                    objlocation.EmailId = dr.GetString(2);
                    objlocation.MobileNo = dr.GetString(3);
                    objlocation.Position  = dr.GetString(4);
                    objlocation.ExamDate = dr.GetString(5);
                    objlocation.StartTime = Convert.ToDateTime(dr.GetString(6)).ToString("HH:mm tt");
                    objlocation.EndTime = System.DateTime.Now.ToString("HH:mm tt");
                    lstEmail.Add(objlocation);

                }


                return lstEmail;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<DataEntity> GetRSIScore(Int32 CanId, string Pdate)
        {
            try
            {
                SqlDataReader dr;
                List<DataEntity> lstRSI = new List<DataEntity>();

                SqlParameter[] param ={

                         new  SqlParameter ("@Examdate",SqlDbType.NVarChar),
                         new  SqlParameter ("@candidateid",SqlDbType.Int)
                                      };
                param[0].Value = Pdate;
                param[1].Value = CanId;

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetRSIScore", param);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    objlocation.QChar = dr.GetString(0);
                    objlocation.Quvalue = dr.GetInt32(1);
                    
                    lstRSI.Add(objlocation);

                }


                return lstRSI;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string  GetPSIScore(Int32 CanId, string Pdate)
        {
            try
            {
                SqlDataReader dr;
               string maxchar=string.Empty ;

                SqlParameter[] param ={

                         new  SqlParameter ("@Examdate",SqlDbType.NVarChar),
                         new  SqlParameter ("@candidateid",SqlDbType.Int)
                                      };
                param[0].Value = Pdate;
                param[1].Value = CanId;

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetcharectorScore", param);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    maxchar = maxchar+ dr.GetString(0);
                   
                   

                }

                return maxchar;
                
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetCAFScore(Int32 CanId, string Pdate)
        {
            try
            {
                SqlDataReader dr;
                string CAFScore = string.Empty;

                SqlParameter[] param ={

                         new  SqlParameter ("@Examdate",SqlDbType.NVarChar),
                         new  SqlParameter ("@candidateid",SqlDbType.Int)
                                      };
                param[0].Value = Pdate;
                param[1].Value = CanId;

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "GetCAFScore", param);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();

                    if (dr.GetValue(0) != DBNull.Value)
                    {
                        CAFScore = dr.GetDecimal(0).ToString();
                    }

                    else
                    {
                        CAFScore = "0";
                    }

                }

                return CAFScore;

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string GetPSIAbbreviations(string score )
        {
            try
            {
                SqlDataReader dr;
                string Abbreviations = string.Empty;

                SqlParameter[] param ={

                         new  SqlParameter ("@qchar",SqlDbType.NVarChar)
                        
                                      };
                param[0].Value = score;

                dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.StoredProcedure, "Get_PSI_Abbreviations", param);
                while (dr.Read())
                {
                    DataEntity objlocation = new DataEntity();
                    if (dr.GetValue(0) != DBNull.Value)
                    {
                        Abbreviations =  dr.GetString(0);
                    }



                }

                return Abbreviations;

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool SaveUpdateRecords(string strCategory,string strCandidateID,DataTable dt)
        {
            bool boolresult = false;
            string strQuery = string.Empty;            
            SqlConnection conn = new SqlConnection(DataConstant.SqlConn);
            DataSet ds = new DataSet();
            conn.Open();
            int j;

            try
            {               
                for (j = 0; j <= dt.Rows.Count - 1; j++)
                {
                    string strID = dt.Rows[j]["ID"].ToString();
                    string strQuesNo = dt.Rows[j]["QuestionNo"].ToString();
                    string strgrade = dt.Rows[j]["Grade"].ToString();
                    string strQues = dt.Rows[j]["Question"].ToString();
                    string strgrade2 = dt.Rows[j]["QuestionGrade"].ToString();


                    //if (Convert.ToInt16(strgrade.ToString()) > 0)
                    //{
                        if (strCategory.ToString().Trim() == "RSI")
                        {
                            strQuery = "IF NOT EXISTS(select * from dbo.MHRI_PSI_RSI_CAF_Scores where Candidateid=" + strCandidateID + " and Category='RSI' and QuesNo='" + strQuesNo + "' and QuestionChar='" + strgrade2 + "' and convert(date,Examdate,101)=convert(date,GETDATE(),101)) " +
           " Insert into MHRI_PSI_RSI_CAF_Scores values(" + strCandidateID + ",getdate(),'" + strQuesNo + "','" + strgrade2 + "','" + strgrade + "','RSI')" +
           " else " +
           " Update MHRI_PSI_RSI_CAF_Scores set value='" + strgrade + "' where Candidateid=" + strCandidateID + " and Category='RSI' and QuesNo='" + strQuesNo + "' and QuestionChar='" + strgrade2 + "' and convert(date,Examdate,101)=convert(date,GETDATE(),101)";
                        }
                        else if (strCategory.ToString().Trim() == "PSI")
                        {
                            strQuery = "IF NOT EXISTS(select * from dbo.MHRI_PSI_RSI_CAF_Scores where Candidateid=" + strCandidateID + " and Category='PSI' and QuesNo='" + strQuesNo + "' and QuestionChar='" + strgrade2 + "' and convert(date,Examdate,101)=convert(date,GETDATE(),101)) " +
           " Insert into MHRI_PSI_RSI_CAF_Scores values(" + strCandidateID + ",getdate(),'" + strQuesNo + "','" + strgrade2 + "','" + strgrade + "','PSI')" +
           " else " +
           " Update MHRI_PSI_RSI_CAF_Scores set value='" + strgrade + "' where Candidateid=" + strCandidateID + " and Category='PSI' and QuesNo='" + strQuesNo + "' and QuestionChar='" + strgrade2 + "' and convert(date,Examdate,101)=convert(date,GETDATE(),101)";
                        }

                        SqlCommand cmd = new SqlCommand(strQuery, conn);

                        cmd.ExecuteNonQuery();
                        boolresult = true;
                    //}
                }
                //trans.Commit;                
                return boolresult;
            }
            catch (Exception ex)
            {
                boolresult = false;
                throw ex;
                //trans.Rollback();                
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet GetListofQuestions(string strCategory)
        {
            DataSet ds = new DataSet();
            string strQuery = null;

            //SqlConnection conn = new SqlConnection(@"Data Source=MOG-PC27111;database=MHRIL;User id=sa;Password=satyam123$;");
            SqlConnection conn = new SqlConnection(DataConstant.SqlConn);
            try
            {
                conn.Open();
                //strQuery = "select ID,QuestionNo,QuestionGrade as Grade,Question, QuestionGrade from dbo.MHRI_Questionnaire where Category='RSI' order by ID,sequenceid";
                strQuery = "select ID,QuestionNo,null as Grade,Question, QuestionGrade from dbo.MHRI_Questionnaire where Category='" + strCategory.Trim() + "' order by ID,sequenceid";
                SqlDataAdapter getdataAdp = new SqlDataAdapter(strQuery, conn);
                getdataAdp.Fill(ds, "QuesInfo");

                return ds;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool IsValidLogin(string strid, string strpwd)
        {
            SqlConnection thisConnection = new SqlConnection(DataConstant.SqlConn);  
            try
            {
                thisConnection.Open();
                SqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT loginid,password,category,EmailId FROM dbo.MHRL_HRLogin WHERE loginid='" + strid.ToString() + "' and password='" + strpwd.ToString() + "' and category=1";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    if (thisReader.GetString(3) != null)
                    {
                        MHRISesstion.HREmailid = thisReader.GetString(3);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                thisReader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                thisConnection.Close();
            }
        }



        public List<DataEntity> GetCAFQuestion()
        {
            List<DataEntity> lstCAFquestion = new List<DataEntity>();

            string sqlquery="select QNo,Q1,COALESCE(Q2,''),A1,A2,A3,A4,COALESCE(ImageURL,'') from CAF";
           


            //SqlCommand cmd = new SqlCommand("select QNo,Q1,COALESCE(Q2,''),A1,A2,A3,A4,COALESCE(ImageURL,'') from CAF", con);


            SqlDataReader dr = SqlHelper.ExecuteReader(DataConstant.SqlConn, CommandType.Text, sqlquery, null); 
            while (dr.Read())
            {
                DataEntity obj = new DataEntity();
                obj.QNo = dr.GetInt32(0);
                obj.Q1 = dr.GetString(1);
                if (dr.GetString(2) != null)
                    obj.Q2 = dr.GetString(2);
                obj.A1 = dr.GetString(3);
                obj.A2 = dr.GetString(4);
                obj.A3 = dr.GetString(5);
                obj.A4 = dr.GetString(6);
                if (dr.GetString(7) != null)
                    obj.strImageURL = dr.GetString(7);
                obj.SelectedAns = 0;
                lstCAFquestion.Add(obj);
            } 



            return lstCAFquestion;

        }


        public void InsertCAFAnswer(DataEntity ObjCAFAnswer,Int32 CandidateId)
        {
            string strQuery = "IF NOT EXISTS(select * from dbo.MHRI_PSI_RSI_CAF_Scores where Candidateid=" + CandidateId + " and Category='CAF' and QuesNo='" + ObjCAFAnswer.QNo + "' and QuestionChar='X' and convert(date,Examdate,101)=convert(date,GETDATE(),101)) " +
                    " Insert into MHRI_PSI_RSI_CAF_Scores values(" + CandidateId + ",getdate(),'" + ObjCAFAnswer.QNo + "','X','" + ObjCAFAnswer.SelectedAns + "','CAF')" +
                    " else " +
                    " Update MHRI_PSI_RSI_CAF_Scores set value='" + ObjCAFAnswer.SelectedAns + "' where Candidateid=" + CandidateId + " and Category='CAF' and QuesNo='" + ObjCAFAnswer.QNo + "' and QuestionChar='X' and convert(date,Examdate,101)=convert(date,GETDATE(),101)";



            SqlHelper.ExecuteNonQuery(DataConstant.SqlConn, CommandType.Text, strQuery, null);

        }


    }
}
