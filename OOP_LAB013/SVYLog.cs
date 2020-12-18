using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OOP_LAB013
{
      public class LogBase
    {
        public DateTime Date { get; private set; }
        public string Action { get; private set; }
        public string ActionPath { get; private set; }

        public LogBase(DateTime date, string action, string actionPath)
        {
            Date = date;
            Action = action;
            ActionPath = actionPath;
        }

        public override string ToString()
        {
            return $"[{Date}] {Action} {ActionPath}";
        }
    }
    public class SVYLog
    {
        private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");

        public string LogFile
        {
            get => _path;
            set
            {
                if (value == _path) throw new ArgumentNullException($"{LogFile}", "Path не ммможет быть равено null");

                _path = value;
            }
        }
        public SVYLog()
        {

        }
        public SVYLog(string path)
        {
            LogFile = path;
        }

        public void WriteLog(string action, string path)
        {
            string output = JsonConvert.SerializeObject(new LogBase(DateTime.Now, action, path));
            var wr = new StreamWriter(LogFile, true);
            wr.Write(output + "\n");
            wr.Dispose();
        }

        public void WriteLog(IEnumerable<LogBase> logBases)
        {
            var wr = new StreamWriter(LogFile, true);
            var output = "";
            foreach(var log in logBases)
            {
                output = JsonConvert.SerializeObject(log);
                wr.Write(output + "\n");
            }
            wr.Dispose();
        }
        public List<LogBase> ReadLog()
        {
            var logList = new List<LogBase>();
            var sr = new StreamReader(LogFile);
            while (!sr.EndOfStream)
            {
                logList.Add(
                    JsonConvert.DeserializeObject<LogBase>(sr.ReadLine() ?? throw new InvalidOperationException()));
            }

            sr.Dispose();

            return logList;
        }

        public IEnumerable<LogBase> DateSearch(DateTime date)
        {
            var logList = ReadLog();

            return logList.Where(x => x.Date == date);
        }

        public IEnumerable<LogBase> ActionSearch(string action)
        {
            var logList = ReadLog();

            return logList.Where(x => x.Action == action);
        }

        public IEnumerable<LogBase> PathSearch(string path)
        {
            var logList = ReadLog();

            return logList.Where(x => x.ActionPath == path);
        }

        public void ClearLog()
        {
            var sw = new StreamWriter(_path);
            sw.Write("");
            sw.Dispose();
        }
    }
}

