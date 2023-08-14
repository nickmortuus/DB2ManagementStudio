using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2ManagementStudio
{
    public class ExcelFile
    {
        public int fileColumns;
        public ExcelRecord headerRow;
        public List<ExcelRecord> records;

        public ExcelFile(int columns)
        {
            fileColumns = columns;
            headerRow = new ExcelRecord(fileColumns);
            records = new List<ExcelRecord>();
        }

        public void AddHeaders(List<string> headers)
        {
            for (int col = 0; col < fileColumns; col++)
            {
                headerRow.record[col] = headers[col];
            }
        }

        public bool CheckForHeaders()
        {
            if (headerRow.record[0] == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddRecord(List<string> recordData)
        {
            ExcelRecord exRecord = new ExcelRecord(fileColumns);

            for (int i = 0; i < fileColumns; i++)
            {
                exRecord.record[i] = recordData[i];
            }

            records.Add(exRecord);
        }


        public void AddRecord(ExcelRecord myRecord)
        {
            records.Add(myRecord);
        }

    }
}
