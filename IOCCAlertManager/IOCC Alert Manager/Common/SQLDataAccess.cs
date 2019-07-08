using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Common
{

    /// <summary>
    /// General Class used for getting data across from the ApplicationVerification database
    /// </summary>
    public class SQLDataAccess : IDisposable
    {

        #region "Region For: Properties"

        internal SqlConnection SqlConn { get; set; }

        internal string connString
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["AlertManagerRespository"].ConnectionString; }
        }

        #endregion

        internal void openSqlConnection()
        {
            if (this.SqlConn == null)
            {
                this.SqlConn = new SqlConnection();
            }

            this.SqlConn.ConnectionString = connString.ToString();

            this.SqlConn.Open();
        }

        internal void closeSqlConnection()
        {
            if (this.SqlConn != null)
            {
                if (SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
                SqlConn.Dispose();
            }
        }

        /// <summary>
        /// Dispose of the object
        /// </summary>
        void IDisposable.Dispose()
        {
            this.closeSqlConnection();
        }

        #region "Region For: Helpers"
        static internal string getConnectionString()
        {
            using (SQLDataAccess da = new SQLDataAccess())
            {
                return da.connString;
            }
        }

        /// <summary>
        /// The return value Parameter (@RETVAL) that I add some stored procedures.  A generic Property here so it can be reused
        /// </summary>
        static internal SqlParameter RecordIdReturnParam
        {
            get
            {
                SqlParameter retVal = new SqlParameter();
                retVal.Direction = ParameterDirection.Output;
                retVal.ParameterName = "@RETVAL";
                retVal.DbType = DbType.Int32;
                return retVal;
            }
        }

        /// <summary>
        /// The return value Parameter (@RETVAL) that I add some stored procedures.  A generic Property here so it can be reused
        /// </summary>
        static internal SqlParameter ReturnParamString
        {
            get
            {
                SqlParameter retVal = new SqlParameter();
                retVal.Direction = ParameterDirection.Output;
                retVal.ParameterName = "@RETVAL";
                retVal.DbType = DbType.String;
                retVal.Size = 36;
                return retVal;
            }
        }

        static internal SqlParameter dateAsParameter(string paramName, System.DateTime val)
        {
            SqlParameter retVal = new SqlParameter();

            retVal.Direction = ParameterDirection.Input;
            retVal.ParameterName = paramName;

            if (val == null || val == System.DateTime.MinValue)
            { retVal.Value = DBNull.Value; }
            else
            { retVal.Value = val; }

            return retVal;
        }

        /// <summary>
        /// Checks if the Date is NULL - returns Date or Date.MinValue
        /// </summary>
        public static DateTime getDateFromDB(object o)
        {
            return o == DBNull.Value ? DateTime.MinValue : (DateTime)o;
        }

        #endregion

        #region "Region For : Reader Helpers"

        /// <summary>
        /// Loads a data table from the request command.
        /// </summary>
        public static DataTable getDataAsTable(string query)
        {
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = query;
                return SQLDataAccess.getDataAsTable(sqlCmd);
            }
        }

        /// <summary>
        /// Loads a data table from the request command.
        /// </summary>
        public static DataTable getDataAsTable(SqlCommand sqlCmd)
        {
            DataTable retVal = null;
            using (DataSet ds = SQLDataAccess.getDataAsDataSet(sqlCmd))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    retVal = ds.Tables[0];
                }
            }
            return retVal;
        }

        /// <summary>
        /// Loads a data table from the request command.
        /// </summary>
        static internal DataSet getDataAsDataSet(SqlCommand sqlCmd)
        {
            DataSet retVal = null;

            using (SqlConnection myConn = new SqlConnection())
            {
                try
                {
                    myConn.ConnectionString = SQLDataAccess.getConnectionString();
                    sqlCmd.Connection = myConn;
                    sqlCmd.CommandTimeout = 0;
                    myConn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);

                            if (ds != null && ds.Tables.Count > 0)
                            {
                                retVal = ds;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    new Logger("Error in getDataAsDataSet() - " + ex.Message);
                    throw;
                }
                finally
                {
                    myConn.Close();
                }

            }

            return retVal;
        }

        #endregion

        #region "Region For : Writer Helpers"

        /// <summary>
        /// Executes Command
        /// </summary>
        static internal bool executeCommand(SqlCommand sqlCmd)
        {
            bool retVal = false;

            using (SqlConnection myConn = new SqlConnection())
            {
                try
                {
                    myConn.ConnectionString = SQLDataAccess.getConnectionString();
                    sqlCmd.Connection = myConn;
                    myConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    retVal = true;
                }
                catch (Exception ex)
                {
                    new Logger("Error in executeCommand() - " + ex.Message);
                    throw;
                }
                finally
                {
                    myConn.Close();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Executes Commands a list of commands in a transaction
        /// </summary>
        static internal bool executeCommandsInTranscation(List<SqlCommand> sqlCmds)
        {
            bool retVal = false;
            SqlTransaction trans = null;

            using (SqlConnection myConn = new SqlConnection())
            {
                try
                {
                    myConn.ConnectionString = SQLDataAccess.getConnectionString();
                    myConn.Open();

                    trans = myConn.BeginTransaction();

                    foreach (SqlCommand sqlCmd in sqlCmds)
                    {
                        sqlCmd.Transaction = trans;
                        sqlCmd.Connection = myConn;
                        sqlCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    retVal = true;
                }
                catch (SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    //Log the Error
                    new Logger("Error in executeCommandsInTranscation() - " + ex.Message);
                    throw;
                }
                //catch //(Exception ex)
                //{
                //    if (trans != null)
                //    {
                //        trans.Rollback();
                //    }
                //    //Log the Error
                //    //ErrorHandler eh = new ErrorHandler();
                //    //eh.saveSQLExceptionToLog(HttpContext.Current.User.Identity.Name, ex);
                //    throw;
                //}
                finally
                {
                    if (trans != null)
                    {
                        trans.Dispose();
                    }
                    myConn.Close();
                }
            }

            return retVal;
        }

        #endregion
    }
}