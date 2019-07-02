using System;
using System.IO;
using System.Reflection;
using context = System.Web.HttpContext;

namespace Common
{
    public class Logger
    {
        private string m_exePath = string.Empty;

        public Logger(string logMessage)
        {
            LogWrite(logMessage);
        }

        public Logger(string logMessage, Exception exdb)
        {
            LogWrite(logMessage, exdb);
            ExceptionLogging.SendExcepToDB(exdb);
        }

        public void LogWrite(string logMessage)
        {
            Directory.CreateDirectory("C:\\Alert Manager Logs");
            m_exePath = "C:\\Alert Manager Logs";
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\Log_" + DateTime.Today.ToString("MM-dd-yyy") + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LogWrite(string logMessage, Exception exdb)
        {
            Directory.CreateDirectory("C:\\Alert Manager Logs");
            m_exePath = "C:\\Alert Manager Logs";
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\Log_" + DateTime.Today.ToString("MM-dd-yyy") + ".txt"))
                {
                    Log(logMessage, w, exdb);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("             :");
                txtWriter.WriteLine("  Message    :  {0}", logMessage);
                txtWriter.WriteLine("  URL        :  {0}", context.Current.Request.Url.ToString());
                txtWriter.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Log(string logMessage, TextWriter txtWriter, Exception exdb)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("             :");
                txtWriter.WriteLine("  Message    :  {0}", logMessage);
                txtWriter.WriteLine("  Type       :  {0}", exdb.GetType().Name.ToString());
                txtWriter.WriteLine("  URL        :  {0}", context.Current.Request.Url.ToString());
                txtWriter.WriteLine("  Stack Trace:  {0}", exdb.StackTrace.ToString());
                txtWriter.WriteLine("------------------------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
