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
        #endregion

        #region Public functions
        public void AddMessage(string name, string message)
        {
            LogEntries.Add(new LogEntry() { Name = name, Message =  message});
        }

        public string GetCompleteLogAsString(bool writelog)
        {
            if (writelog)
            {
                var log = string.Join("\n\n", LogEntries.Select(p => $"{p.Name}: \n {p.Message}"));
                return $"/** {log} **/";
            }

            return String.Empty;
        }
        #endregion
    }
}
