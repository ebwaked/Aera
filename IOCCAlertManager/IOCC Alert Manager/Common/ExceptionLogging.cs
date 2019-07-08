using System;
using context = System.Web.HttpContext;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Common
{
    /// <summary>  
    /// Summary description for ExceptionLogging
    /// </summary>  
    public static class ExceptionLogging
    {
        private static String exepurl;

        public static void SendExcepToDB(Exception exdb)
        {
            try
            {
                using (SqlCommand myCmd = new SqlCommand())
                {
                    exepurl = context.Current.Request.Url.ToString();
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.CommandText = "[dbo].[EXCEPTION_LOGGING]";
                    myCmd.Parameters.AddWithValue("@XCPN_MSG_TXT", exdb.Message.ToString());
                    myCmd.Parameters.AddWithValue("@XCPN_TYPE_TXT", exdb.GetType().Name.ToString());
                    myCmd.Parameters.AddWithValue("@XCPN_URL_TXT", exepurl);
                    myCmd.Parameters.AddWithValue("@XCPN_SS_TXT", exdb.StackTrace.ToString());

                    // Execute
                    SQLDataAccess.executeCommand(myCmd);
                }
            }
            catch (Exception ex)
            {
                new Logger("Exception logger error sending to DB: " + ex.Message + "****STACKTRACE****" + ex.StackTrace);
            }
        }

    }
}
