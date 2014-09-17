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
using System.Configuration;

namespace Exam
{
    public static class DataConstant
    {

        public static string SqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["SQLDBConnString"].ConnectionString;
        public static string CAFTestDuration = System.Configuration.ConfigurationManager.AppSettings["CAFTestDuration"];
        public static string PSIRange = System.Configuration.ConfigurationManager.AppSettings["PSIRange"];
        public static string RSIRange = System.Configuration.ConfigurationManager.AppSettings["RSIRange"];
        public static string RSInoofPages = System.Configuration.ConfigurationManager.AppSettings["RSInoofPages"].ToString();
        public static string PSInoofPages = System.Configuration.ConfigurationManager.AppSettings["PSInoofPages"].ToString();
  
      
    }
}
