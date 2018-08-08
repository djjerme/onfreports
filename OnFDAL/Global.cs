using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace PBA.OnfDAL
{
    public class DataAccess
    {
        protected static string dbConnection = ConfigurationManager.AppSettings["dbConnection"].ToString();
        protected static string dbConnectionArchive = ConfigurationManager.AppSettings["dbConnectionArchive"].ToString();
        protected static EventLog mEventLog = new EventLog
                                           {
                                               Source = "Application"
                                           };

        public static DateTime? NCD(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(s);
        }

        public static int? NCI(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt32(s);
        }

        public static double? NCDbl(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToDouble(s);
        }

        public static decimal? NCDcm(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(s);
        }

        public static bool? NCB(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToBoolean(s);
        }

        public static string NCS(object s)
        {
            if (s == System.DBNull.Value)
                return null;
            else
                return Convert.ToString(s);
        }

        public static string NCS(object s, string DefaultValue)
        {
            if (s == System.DBNull.Value)
            {
                return DefaultValue;
            }
            else
            {
                return Convert.ToString(s);
            }
        }

        /// <summary>
        /// Used for properly formatting values for update and insert statements.
        /// </summary>
        public static string nullChk(object s)
        {
            String fvalue;
            
            if (s == null)
            {
                return "null";
            }
            else
            {
                fvalue = Escape(s.ToString());
                if (s.GetType() == typeof(string) || s.GetType() == typeof(DateTime)) 
                {
                    fvalue = "'" + fvalue + "'"; 
                }

                if (s.GetType() == typeof(bool))
                {
                    fvalue = BoolToSqlBit((bool) s).ToString();
                }

                return fvalue;
            }
        }

        public static string Escape(string sql)
        {
            string escapedSQL = string.Empty;

            if (sql != string.Empty && sql != null)
            {
                escapedSQL = sql.Replace("'", "''");

            }

            return escapedSQL;

        }

        public static int BoolToSqlBit(bool input)
        {
            if (Convert.ToBoolean(input))
            {
                return  1;
            }
            else
            {
                return  0;
            }

        }

        public static bool SqlBitToBool (object input)
        {
            return Convert.ToBoolean(input);

        }
    }




}
