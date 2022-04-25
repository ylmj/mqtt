using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMq.core
{
    public static class Logger
    {
        public enum LogLevel
        {
            Debug=0,
            Info=1,
            Warn=2,
            Error=3,
            Fatal=4
        }
        public static string TraceLog(LogLevel level,string message)
        {
            return string.Format(">>{0} [{1}]-{2}",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),level.ToString(),message);
        }
    }
}
