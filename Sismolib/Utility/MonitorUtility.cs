using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sismolib.Utility
{
    public static class MonitorUtility
    {
        public static Monitor MonitorInteface;
        public static Thread thrdMonitor;

        public static void StartMonitorInterface()
        {
            
            MonitorInteface = new Monitor();
            MonitorInteface.Show();
        }

    }
}
