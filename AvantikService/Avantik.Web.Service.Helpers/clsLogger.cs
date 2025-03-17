using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Specialized;

namespace Avantik.Web.Service.Helpers
{
    public class Logger
    {
        public enum LogType
        {
            File,
            Mail
        };
     
        //private static declaration.
        static LogType _logType;
        static Logger _instance;
        static string _LogAddress;
        static string _smtpServer;
        static string _application;
        static string _airline;
        static bool _ExistingInstance;
        #region Property
        public static Logger Instance(LogType logType)
        {
            if (_instance == null)
            {
                _instance = new Logger();
                _ExistingInstance = false;

                //initial configuration.
                NameValueCollection setting= (NameValueCollection)ConfigurationManager.GetSection("ErrorLog");

                if (setting.ToString("logtype") == "MAIL")
                {
                    //Set log Type.
                    _logType = LogType.Mail;

                    //Set mail error address
                    _smtpServer = setting.ToString("SmtpServer");
                    _LogAddress = setting.ToString("ErrorTo");
                    _application = setting.ToString("application");
                    _airline = setting.ToString("airline");
                }
            }
            else
            {
                _ExistingInstance = true;
            }

            return _instance;
        }
        #endregion

        #region Method
        public void WriteLog(Exception ex, string inputParameter)
        {
            CreateLog(_application,
                    _airline,
                    inputParameter,
                    ex.Message,
                    ex.StackTrace,
                    ex.TargetSite.DeclaringType.FullName,
                    ex.TargetSite.Name,
                    string.Empty);
        }
        public void WriteLog(string inputParameter, string logMessage, string errorLocation, string functionName, string applicationName, string traceMessage)
        {
            CreateLog(_application,
                      _airline,
                      inputParameter,
                      logMessage,
                      traceMessage,
                      errorLocation,
                      functionName,
                      applicationName);
        }
        #endregion

        #region Helper
        private void CreateLog(string application,
                               string airline,
                               string strInput, 
                               string strMessage, 
                               string strTrace, 
                               string strLocation, 
                               string strFunctionName,
                               string ApplicationType)
        {
            try
            {
                if (_logType == LogType.Mail)
                {
                    WriteLogMail(application,
                                 airline,
                                 strInput,
                                 strMessage,
                                 strTrace,
                                 strLocation,
                                 strFunctionName,
                                 ApplicationType);
                }
                else
                {
                    WriteLogFile(strInput,
                                 strMessage,
                                 strTrace,
                                 strLocation,
                                 strFunctionName,
                                 ApplicationType);
                }
            }
            catch
            { }
        }

        private void WriteLogMail(string application,
                                  string airline,
                                  string strInput,
                                  string strMessage,
                                  string strTrace,
                                  string strLocation,
                                  string strFunctionName,
                                  string ApplicationType)
        {
            try
            {
                if (string.IsNullOrEmpty(_smtpServer) == false)
                {
                    //Implement Writelog File.
                    StringBuilder stbHtml = new StringBuilder();

                    stbHtml.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                    stbHtml.Append("<body>");
                    stbHtml.Append("<table width='400' border='0' cellpadding='4' cellspacing='2' bgcolor='#B4CBD6' style='margin:0px auto; font-family:Arial, Helvetica, sans-serif; font-size:12px; color:#304974;'>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Date</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + " [Existing Instance = " + _ExistingInstance.ToString() + "]</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>App Type</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>" + application + "</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Airline</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>" + airline + "</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Location</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>" + strLocation + "</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Function</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>" + strFunctionName + "</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Input Parameter</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>");
                    stbHtml.Append(strInput.Replace("<", "&lt;").Replace(">", "&gt;"));
                    stbHtml.Append("</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Massage</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>");
                    stbHtml.Append(strMessage);
                    stbHtml.Append("</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("<tr>");
                    stbHtml.Append("<td width='20%' valign='top' bgcolor='#FFFFFF' style='font-weight:bold;'>Trace</td>");
                    stbHtml.Append("<td valign='top' bgcolor='#FFFFFF'>");
                    stbHtml.Append(strTrace);
                    stbHtml.Append("</td>");
                    stbHtml.Append("</tr>");
                    stbHtml.Append("</table>");
                    stbHtml.Append("</body>");
                    stbHtml.Append("</html>");

                    //Call Mail function
                    //Send Error Email.
                    SendMailSmtp(_smtpServer,
                                 System.Environment.MachineName + "@mercator.asia",
                                 _LogAddress,
                                 string.Empty,
                                 "[" + strFunctionName + "] - " + strLocation,
                                 stbHtml.ToString(),
                                 true);
                }
            }
            catch
            { }
        }

        private void WriteLogFile(string strInput,
                                  string strMessage,
                                  string strTrace,
                                  string strLocation,
                                  string strFunctionName,
                                  string ApplicationType)
        {

            //Implement Writelog File.
            StringBuilder stbHtml = new StringBuilder();

            stbHtml.Append("***********************Date****************************");
            stbHtml.Append(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + Environment.NewLine);
            stbHtml.Append("Location :  " + strLocation + Environment.NewLine);
            stbHtml.Append("Function :  " + strFunctionName + Environment.NewLine);
            stbHtml.Append("Input Parameter----------------------------------------" + Environment.NewLine);
            stbHtml.Append(strInput + Environment.NewLine);
            stbHtml.Append("Massage------------------------------------------------" + Environment.NewLine);
            stbHtml.Append(strMessage + Environment.NewLine);
            stbHtml.Append("Trace--------------------------------------------------"  + Environment.NewLine);
            stbHtml.Append(strTrace +  Environment.NewLine);

            //Save log file.

        }

        private bool SendMailSmtp(string smtpServer, string mailForm, string mailTo, string mailBcc, string mailSubject, string mailBody, bool isHtml)
        {
            bool bResult = false;
            if (smtpServer.Length > 0)
            {
                MailMessage message = null;
                try
                {
                    // Command line argument must the the SMTP host.
                    SmtpClient client = new SmtpClient(smtpServer);
                    MailAddress from = new MailAddress(mailForm,
                                                       mailForm,
                                                       System.Text.Encoding.UTF8);

                    MailAddress to = new MailAddress(mailTo);
                    message = new MailMessage(from, to);

                    if (mailBcc.Length > 0)
                    { message.Bcc.Add(mailBcc); }

                    message.IsBodyHtml = isHtml;
                    message.Body = mailBody;

                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = mailSubject;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                    client.Send(message);
                    bResult = true;
                }
                catch
                {
                    bResult = false;
                }
                finally
                {
                    if (message != null)
                    {
                        // Clean up.
                        message.Dispose();
                    }
                }
            }
            else
            { bResult = false; }

            return bResult;
        }
        #endregion
    }
}
