using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dapper.Accelr8.Repo
{
    public static class Diagnostics
    {
#if DEBUG
        static System.Threading.Timer _timer = new System.Threading.Timer
            (new System.Threading.TimerCallback(Update)
            , null, 60000, 60000);
#endif

        static long _recent;

        internal static void Update(object state)
        {
            var count = _recent;

            _recent = 0;

            ScriptsRunPerMinute  = (ScriptsRunPerMinute + count) / 2.0m;
        }

        public static decimal ScriptsRunPerMinute;
        public static bool LogAllSql;

        public static void Increment(int count)
        {
            _recent += count;
        }
    }
}
