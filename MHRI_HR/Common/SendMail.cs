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
namespace Exam
{
    public class SendMail
    {
        public string Candidatename = "";
        public string Subject;
        public void SendEmail( Int32 Canid, string pdate)
        {

            DataAccess DEmail = new DataAccess();
            List<DataEntity> lst = new List<DataEntity>();
            List<DataEntity> lstrsi = new List<DataEntity>();

             
            if (MHRISesstion.HREmailid != "")
            {

                Int32 Canditeid = Canid;

                String Pdate = pdate;
                lst = DEmail.GetCandidateDetails(Canditeid, Pdate);
                string body = "<html> Hi </br></br> Please find the report of the pre-employment test below:</br></br></br> Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:[Name]</br> Email ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:[Emailid]</br> Mobile Number&nbsp;&nbsp;&nbsp;&nbsp;:[Mobile]</br> Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:[Position]</br> Exam Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:[ExamDate]</br>Exam Start Time&nbsp;&nbsp;:[StartTime]</br>Exam End Time&nbsp;&nbsp;&nbsp;:[EndTime] ";
                if (lst.Count > 0)
                {

                    body = body.Replace("[Name]", lst[0].FirstName);
                    Candidatename = lst[0].FirstName;
                    body = body.Replace("[Emailid]", lst[0].EmailId);
                    body = body.Replace("[Mobile]", lst[0].MobileNo);
                    body = body.Replace("[Position]", lst[0].Position);
                    body = body.Replace("[ExamDate]", lst[0].ExamDate);
                    body = body.Replace("[StartTime]", lst[0].StartTime);
                    body = body.Replace("[EndTime]", lst[0].EndTime);
                    
                }

                string CAFscore=DEmail.GetCAFScore(Canditeid, Pdate);

                //body = body + "</br></br></br></br> Section 1: CAF </br> Score obtained is " + CAFscore + " out of " + 15 + "</br></br> Section 2: RSI</br> The score of various career anchor are below : <table > ";
                body = body + "</br></br></br></br> Section 1: CAF </br> Score obtained is " + CAFscore + " out of " + 15;
                body = body + "</br> CAF Examination Duration is " + MHRISesstion.CandidateCAFduration.ToString() + "mins" ;
                body = body + "</br></br> Section 2: RSI</br> The score of various career anchor are below : <table > ";

                lstrsi = DEmail.GetRSIScore(Canditeid, Pdate);


                if (lstrsi.Count > 0)
                {
                    foreach (var obj in lstrsi)
                    {
                        DataEntity D1 = new DataEntity();



                        body = body + "<tr> <td>" + obj.QChar + "</td>" + "<td>" + obj.Quvalue + "</td></tr>";
                    }

                }

                body = body + "</table>";
                body = body + " </br></br> Section 3: PSI </br> The Profile according of PSI is :";//      +</html>";

                string psiscore = DEmail.GetPSIScore(Canditeid, Pdate);
                body = body + psiscore;




                string StrAbbreviations = DEmail.GetPSIAbbreviations(psiscore);

                if (StrAbbreviations != "")
                {
                    string bodypart = " </br> A short description of the same is below :- </br> <table > <tr> <td > </td> <td  >" + StrAbbreviations + "</td <td > </td> </tr> </table></html>";
                    body = body + bodypart;
                }

                else
                {
                    body = body + "</html>";
                }



                if (Candidatename != "")
                {
                    Subject = "Pre-Employment test score for candidate:-" + "  " + Candidatename;
                }
                
                else
                {
                    Subject = "Pre-Employment test score for candidate:-" + "  ";
                }

                

               
              EmailUtil.MHRISendMail(null, MHRISesstion.HREmailid, null, null, Subject, body, null, null, null, null, null);
             //EmailUtil.MHRISendMailTest(null, MHRISesstion.HREmailid, null, null, Subject, body, null, null, null, null, null);
            }
        }

    }
}
