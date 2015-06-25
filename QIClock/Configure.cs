using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QIClock
{
    class Configure
    {
        public static string IP
        {
            get;
            set;
        }
        public static string Port
        {
            get;
            set;
        }
        public static DateTime Time
        {
            get;
            set;
        }
        public static int NumberDays
        {
            get;
            set;
        }

        public static DateTime FromDate
        {
            get;
            set;
        }

        public static DateTime ToDate
        {
            get;
            set;
        }

        public static bool IsAuto
        {
            get;
            set;
        }

        public static bool isTime
        {
            get;
            set;
        }

        public static int Interval
        {
            get;
            set;
        }
    }
}
