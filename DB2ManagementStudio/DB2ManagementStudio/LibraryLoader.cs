using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2ManagementStudio
{
    internal class LibraryLoader
    {
        public static DataTable LoadLibrary(string schema, string system)
        {
            DataTable dt = SQLLink.grabIbmData($"select * from QSYS2.SYSTABLES where TABLE_SCHEMA = '{schema}'AND TYPE = 'P'", system);
            return dt;
        }
        public static DataTable LoadLibrary(string connectionName)
        {
            DataTable dt = SQLLink.grabIbmData("select * from QSYS2.SYSTABLES where TABLE_SCHEMA = 'ITSFILE'AND TYPE = 'P'", connectionName);
            return dt;
        }

        public static DataTable GetTableData(string tableName, string schema, string connectionName)
        {
            DataTable dt = SQLLink.grabIbmData($"select * from sysibm.columns where table_schema = '{schema}' and table_name = '{tableName}'", connectionName);
            return dt;
        }

        public static string FindDataType(string data)
        {
            data = data.ToLower().Trim();
            switch (data)
            {
                case "character":
                    return "char";
                case "integer":
                    return "int";
                case "character varying":
                    return "varchar";
                default:
                    return data;
            }
        }

        public static string FindDataLength(string dataType,DataRow row)
        {
            List<string> charData = new List<string>()
            {
                "char",
                "varchar",
            };

            if(charData.Contains(dataType))
            {
                // it is a character field
               return row["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim();
            }
            else
            {
                // it is a number field.
                return row["NUMERIC_PRECISION"].ToString().Trim();
            }
        }

    }
}
