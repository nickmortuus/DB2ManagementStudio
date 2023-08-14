using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2ManagementStudio
{
    internal class Logger
    {
        string status;
        string message;

        public Logger()
        {

        }

        public void Log(string logPath, string logMsg)
        {
            File.WriteAllText(logPath, logMsg);
        }

        public void LogWithTime(string logPath, string logMsg)
        {
            string time = DateTime.Now.ToString();
            File.AppendAllText(logPath, Environment.NewLine + "[" + time + "]" + " " + logMsg);
        }

        public static void WriteToLog(string textToLog)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\log.txt";
            try
            {
                string time = DateTime.Now.ToString();
                string text = textToLog;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.AppendAllText(filepath, Environment.NewLine + "[" + time + "]" + " " + text);
            }
            catch (Exception ex)
            {
                // do nothing can't write to log
            }
        }
    }
}
