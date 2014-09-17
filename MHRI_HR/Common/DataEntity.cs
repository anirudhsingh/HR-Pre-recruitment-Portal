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

namespace Exam
{
    public class DataEntity
    {
        public Int32 LocationID { get; set; }
        public string LocationName { get; set; }
        public Int32 PositionID { get; set; }
        public string Position { get; set; }

        public Int32 QualificationId { get; set; }
        public string Qualification { get; set; }

        public Int32 ExperienceId { get; set; }
        public string Experience { get; set; }

        public string FirstName { get; set; }
        public string FirstNameTodisplayExampage { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public Int32 FQuNo { get; set; }
        public string QueGrade { get; set; }
        public string RuntimeQuestion { get; set; }

        public Int32 Quvalue { get; set; }
        public string QChar { get; set; }
        public string PanNo { get; set; }
        public Int32  AcceptDec { get; set; }

        public string ExamDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public Int32 QNo { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public int SelectedAns { get; set; }
        public string strImageURL { get; set; }
        public bool IsImageURL { get; set; }

    }
}
