using IBM.Data.DB2.iSeries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2ManagementStudio
{
    internal class SQLLink
    {

        public static DataTable grabSqlData(string query)
        {
            //DataTable dt = new DataTable();

            //try
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        // Create adapter to grab table rows
            //        SqlDataAdapter sda = new SqlDataAdapter(query, con);
            //        sda.Fill(dt);
            //    }
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteToLog(ex.Message.ToString());
            //}

            //return dt;
            return null;
        }

        public static void DoSqlCmd(string query)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(query, con))
            //        {
            //            con.Open();
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteToLog(ex.Message.ToString());
            //}

        }

        public static void CallSP(string procedureName)
        {
            //try
            //{
            //    using (var conn = new SqlConnection(connectionString))
            //    using (var command = new SqlCommand(procedureName, conn)
            //    {
            //        CommandType = CommandType.StoredProcedure
            //    })
            //    {
            //        conn.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteToLog(ex.Message.ToString());
            //}

        }

        public static void CallSPWithParameters(string procedureName, int paramCount, string[] parameters, string[] parameterValues)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        using (SqlCommand cmd = new SqlCommand(procedureName, con))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            // Add parameters
            //            for (int i = 0; i < paramCount; i++)
            //            {
            //                cmd.Parameters.Add(new SqlParameter(parameters[i], parameterValues[i]));
            //            }

            //            con.Open();
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.WriteToLog(ex.Message.ToString());
            //}

        }



        public static void executeIbmQuery(string query)
        {

            //DataTable dt = new DataTable();

            //using (iDB2Connection con = new iDB2Connection(iconnectionString))
            //{
            //    con.Open();
            //    iDB2Command cmd = con.CreateCommand();
            //    //iDB2Transaction trans = con.BeginTransaction();
            //    //cmd.Transaction = trans;
            //    cmd.CommandText = query;

            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

        }
       
        public static DataTable grabIbmData(string query, string systemToQuery)
        {
            // local connection string
            DataTable dt = new DataTable();

            var connectionString = ConfigHelper.CnnString(systemToQuery);

            try
            {
                using (iDB2Connection con = new iDB2Connection(connectionString))
                {
                    iDB2DataAdapter ida = new iDB2DataAdapter(query, con);
                    ida.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteToLog(ex.Message);
                Form1.outputData += Environment.NewLine + $"[{DateTime.Now.ToString()}]: {ex.Message}";
            }

            return dt;
        }
    }
}
