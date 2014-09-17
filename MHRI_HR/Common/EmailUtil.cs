using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Exam
{
    public class EmailUtil
    {
        public static void SendMail(string from, string to, string cc, string bcc, System.Net.Mail.MailPriority priority, string subject,string body, bool bodyFormat, System.Text.Encoding bodyEncoding, string[] AttachedfilesNames)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();
            body = body.Replace("[LINK]", ConfigurationManager.AppSettings["WETOS_Link"].ToString());
            objMail.To.Add(to);
            objMail.To.Add(from);

            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"]);  
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(cc);
            }
            if (!String.IsNullOrEmpty(bcc))
            {
                objMail.Bcc.Add(bcc);
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = bodyFormat;
            objMail.BodyEncoding = bodyEncoding;
            objMail.Body = body;
            if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            {
                for (int i = 0; i < AttachedfilesNames.Length; i++)
                {
                    objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
                }
            }
            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            //objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = false;
             
            //NetworkCredential credential = new NetworkCredential("Sharad@eviska.com", "Sharad");
            objSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }


        public static void SendMail(string from, string to, string cc, string bcc, string subject,string body, string[] AttachedfilesNames)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();
            body = body.Replace("[LINK]", ConfigurationManager.AppSettings["WETOS_Link"].ToString());
            objMail.To.Add(to);
            objMail.CC.Add(from);
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"]);  
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(cc);
            }
            if (!String.IsNullOrEmpty(bcc))
            {
                objMail.Bcc.Add(bcc);
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            {
                for (int i = 0; i < AttachedfilesNames.Length; i++)
                {
                    objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
                }
            }
            
            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            //objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = false;
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
           // NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            objSmtpClient.Credentials = credential;
            //objSmtpClient.EnableSsl = true;
            objSmtpClient.Port = 26;
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        public static void SendMail(string from, string to, string cc, string bcc, string subject, string body, string[] AttachedfilesNames, string sender, string receiver)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();
            body = body.Replace("[LINK]", ConfigurationManager.AppSettings["WETOS_Link"].ToString());
            //objMail.To.Add(new MailAddress(to, receiver));
            //objMail.CC.Add(new MailAddress(from, sender));
            objMail.To.Add(new MailAddress("wetos@eviska.com", receiver));
            objMail.CC.Add(new MailAddress("simanchal@eviska.com", sender));
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"], sender);
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(cc);
            }
            if (!String.IsNullOrEmpty(bcc))
            {
                objMail.Bcc.Add(bcc);
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            {
                for (int i = 0; i < AttachedfilesNames.Length; i++)
                {
                    objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
                }
            }

            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            //objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = false;
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            // NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            objSmtpClient.Credentials = credential;
            //objSmtpClient.EnableSsl = true;
            objSmtpClient.Port = 26;
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }

        }
        public static void SendMail(string from, string to, string cc,string cc1, string bcc, string subject, string body, string[] AttachedfilesNames, string sender, string receiver)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();
            body = body.Replace("[LINK]", ConfigurationManager.AppSettings["WETOS_Link"].ToString());
            //objMail.To.Add(new MailAddress(to, receiver));
            //objMail.CC.Add(new MailAddress(from, sender));
            objMail.To.Add(new MailAddress(to, receiver));
            //objMail.CC.Add(new MailAddress("simanchal@eviska.com", sender));
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"], sender);
            if (!String.IsNullOrEmpty(from))
            {
                objMail.CC.Add(from);
            }
                if (!String.IsNullOrEmpty(cc))
                {
                    objMail.CC.Add(cc);
                }
                if (!String.IsNullOrEmpty(cc1))
                {
                    objMail.CC.Add(cc1);
                }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            {
                for (int i = 0; i < AttachedfilesNames.Length; i++)
                {
                    objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
                }
            }

            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            //objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = false;
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            // NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            objSmtpClient.Credentials = credential;
            //objSmtpClient.EnableSsl = true;
            objSmtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        public static void SendMail(string from, string to, string cc, string cc1, string bcc, string subject, string body, string[] AttachedfilesNames, string sender, string receiver, string cc1name, string cc2name, string cc3name)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();

            body=body.Replace("[LINK]", ConfigurationManager.AppSettings["WETOS_Link"].ToString());
            //objMail.To.Add(new MailAddress(to, receiver));
            //objMail.CC.Add(new MailAddress(from, sender));
            objMail.To.Add(new MailAddress(to, receiver));
            //objMail.CC.Add(new MailAddress("simanchal@eviska.com", sender));
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"], sender);
            if (!String.IsNullOrEmpty(from))
            {
                objMail.CC.Add(new MailAddress(from , cc1name));
            }
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(new MailAddress(cc, cc2name));
            }
            if (!String.IsNullOrEmpty(cc1))
            {
                objMail.CC.Add(new MailAddress(cc1, cc3name));
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            {
                for (int i = 0; i < AttachedfilesNames.Length; i++)
                {
                    objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
                }
            }

            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            //objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = false;
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            // NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            objSmtpClient.Credentials = credential;
            //objSmtpClient.EnableSsl = true;
            objSmtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        public static void MHRISendMail(string from, string to, string cc, string cc1,string subject, string body, string sender, string receiver, string cc1name, string cc2name, string cc3name)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();

           // body = body.Replace("[LINK]", ConfigurationManager.AppSettings["Link"].ToString());
            //objMail.To.Add(new MailAddress(to));
            //objMail.CC.Add(new MailAddress(from, sender));
            objMail.To.Add(new MailAddress(to));
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"]);
            //objMail.From = new MailAddress("Feedback@clubmahindra.com");
            //objMail.From = "Feedback@clubmahindra.com";
            //objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"], sender);
            //if (!String.IsNullOrEmpty(from))
            //{
            //    objMail.CC.Add(new MailAddress(from, cc1name));
            //}
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(new MailAddress(cc, cc2name));
            }
            if (!String.IsNullOrEmpty(cc1))
            {
                objMail.CC.Add(new MailAddress(cc1, cc3name));
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            //if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            //{
            //    for (int i = 0; i < AttachedfilesNames.Length; i++)
            //    {
            //        objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
            //    }
            //}

            //objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            ////objSmtpClient = new SmtpClient("67.212.165.234");
            //objSmtpClient.UseDefaultCredentials = true;
            ////NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            //// NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            //objSmtpClient.Credentials = credential;
            //objSmtpClient.EnableSsl = true;
            //objSmtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);

            SmtpClient objSmtpClient1 = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"], int.Parse(ConfigurationManager.AppSettings["SMTPPort"]));
           // SmtpClient objSmtpClient1 = new SmtpClient("172.16.16.21", 25);

            try
            {
                objSmtpClient1.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        public static void MHRISendMailTest(string from, string to, string cc, string cc1, string subject, string body, string sender, string receiver, string cc1name, string cc2name, string cc3name)
        {
            MailMessage objMail;
            SmtpClient objSmtpClient = null;
            to = to.Replace(";", ",");
            objMail = new MailMessage();

            // body = body.Replace("[LINK]", ConfigurationManager.AppSettings["Link"].ToString());
            //objMail.To.Add(new MailAddress(to));
            //objMail.CC.Add(new MailAddress(from, sender));
            objMail.To.Add(new MailAddress(to));
            //objMail.From = new MailAddress("Feedback@clubmahindra.com");
            //objMail.From = "Feedback@clubmahindra.com";
            objMail.From = new MailAddress(ConfigurationManager.AppSettings["SMTPUsername"], sender);
            //if (!String.IsNullOrEmpty(from))
            //{
            //    objMail.CC.Add(new MailAddress(from, cc1name));
            //}
            if (!String.IsNullOrEmpty(cc))
            {
                objMail.CC.Add(new MailAddress(cc, cc2name));
            }
            if (!String.IsNullOrEmpty(cc1))
            {
                objMail.CC.Add(new MailAddress(cc1, cc3name));
            }
            objMail.Priority = MailPriority.High;
            objMail.Subject = subject;
            objMail.IsBodyHtml = true;
            objMail.BodyEncoding = System.Text.Encoding.Default;
            objMail.Body = body;
            //if (AttachedfilesNames != null && AttachedfilesNames.Length > 0)
            //{
            //    for (int i = 0; i < AttachedfilesNames.Length; i++)
            //    {
            //        objMail.Attachments.Add(new Attachment(AttachedfilesNames[i]));
            //    }
            //}

            objSmtpClient = new SmtpClient(ConfigurationManager.AppSettings["SMTPServerName"]);
            ////objSmtpClient = new SmtpClient("67.212.165.234");
            objSmtpClient.UseDefaultCredentials = true;
            //NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUsername"], ConfigurationManager.AppSettings["SMTPPassword"]);
            // NetworkCredential credential = new NetworkCredential("prashant@eviska.com", "prashant");
            objSmtpClient.Credentials = credential;
            objSmtpClient.EnableSsl = true;
            objSmtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);

           // SmtpClient objSmtpClient1 = new SmtpClient("172.16.16.21", 25);

            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

    }
}