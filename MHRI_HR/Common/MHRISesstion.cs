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
    public class MHRISesstion
    {


        public static string CandidateId
        {

            get { return HttpContext.Current.Session["CandidateId"] as string; }
            set { HttpContext.Current.Session["CandidateId"] = value; }
   

        }

        public static string HREmailid
        {

            get { return HttpContext.Current.Session["HREmailid"] as string; }
            set { HttpContext.Current.Session["HREmailid"] = value; }


        }

        public static string HRCandidateFirstName
        {

            get { return HttpContext.Current.Session["HRCandidateFirstName"] as string; }
            set { HttpContext.Current.Session["HRCandidateFirstName"] = value; }


        }

        //public static string TimeLeftofCAFTest
        //{

        //    get { return HttpContext.Current.Session["TimeLeftofCAFTest"] as string; }
        //    set { HttpContext.Current.Session["TimeLeftofCAFTest"] = value; }


        //}

        
        public static string CandidateCAFduration
        {

            get { return HttpContext.Current.Session["TimeTakenforCAFTest"] as string; }
            set { HttpContext.Current.Session["TimeTakenforCAFTest"] = value; }


        }

    }
}
