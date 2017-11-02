using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyGenerator.Container;
using ProxyGenerator.Interfaces;

namespace ProxyGenerator.Manager
{
    public class LogManager : ILogManager
    {
        #region Member
        private List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();

        public static string LogfilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "proxyGeneratorLog.txt");

        public bool WriteLog { get; set; } = false;
        #endregion

        #region Public functions
        public void AddMessage(string name, string message)
        {
            LogEntries.Add(new LogEntry() { Name = name, Message =  message});
        }

        public string GetCompleteLogAsString(bool writelog)
        {
            WriteLog = writelog;

            if (WriteLog)
            {
                var log = string.Join("\n\n", LogEntries.Select(p => $"{p.Name}: \n {p.Message}"));
                return $"/** {log} **/";
            }

            return String.Empty;
        }

        public static void Log(bool writeLog, params string[] txt)
        {
            if (writeLog)
            {
                System.IO.File.AppendAllText(LogfilePath, string.Join(": ", txt) + Environment.NewLine);
            }
        }
        #endregion
    }
}
