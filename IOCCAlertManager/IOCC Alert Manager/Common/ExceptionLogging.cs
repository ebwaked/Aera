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
        static SqlConnection con;

        private static void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["AlertManagerRespository"].ToString();
            con = new SqlConnection(constr);
            con.Open();
        }

        public static void SendExcepToDB(Exception exdb)
        {
            try
            {
                connection();
                exepurl = context.Current.Request.Url.ToString();
                SqlCommand com = new SqlCommand("EXCEPTION_LOGGING", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@XCPN_MSG_TXT", exdb.Message.ToString());
                com.Parameters.AddWithValue("@XCPN_TYPE_TXT", exdb.GetType().Name.ToString());
                com.Parameters.AddWithValue("@XCPN_URL_TXT", exepurl);
                com.Parameters.AddWithValue("@XCPN_SS_TXT", exdb.StackTrace.ToString());
                com.ExecuteNonQuery();   // TODO FIX - Invalid object - OperationsAlertManager
            }
            catch (Exception ex)
            {
                new Logger("Exception logger error sending to DB: " + ex.Message + "****STACKTRACE****" + ex.StackTrace);
            }
        }

    }
}
