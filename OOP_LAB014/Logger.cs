using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB014
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
            return $"[{Date}] {ActionPath}";
        }
    }
    public class Log
    {
            
            private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "log.txt");
        public string LogFile
        {
            get => _path;
            set
            {
                if (value == _path) throw new ArgumentNullException($"{LogFile}", "Path не ммможет быть равено null");

                _path = value;
            }
        }
        public Log() { }
        public Log(string path)
        {
            LogFile = path;
        }

        public static void WriteLog(string path, string action)
        {
            string output = JsonConvert.SerializeObject(new LogBase(DateTime.Now, action, path));
            var wr = new StreamWriter(path, true);
            wr.Write(output + "\n");
            wr.Dispose();
        }
    } 

}
