using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2ManagementStudio
{
    public class ExcelRecord
    {
        public string[] record;

        public ExcelRecord(int columns)
        {
            record = new string[columns];
        }
    }
}
