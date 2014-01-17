using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sismolib.Utility;

namespace Sismolib
{
    /// <summary>
    /// Enumeratore per la selezione dell'asse su cui sono stati rilevati i valori, 
    /// si può recuperare la stringa utilizzando l'enumeratore come indice del vettore SismoAxisVet
    /// </summary>
    public enum SismoAxis { Undefinied = -1, X = 0, Y, Z };

    public class Sismo
    {
        InputReader reader;
        Thread serviceThrd;
        
        /// <summary>
        /// 
        /// </summary>
        public event DataConvertedEventHandler DataConverted;

        public Sismo()
        {
            SismoNotifyIcon.CreateNotifyicon();
        }
        public void StartAcquisition()
        {
            Thread thrdMonitor = new Thread(MonitorUtility.StartMonitorInterface);
            thrdMonitor.IsBackground = true;
            thrdMonitor.Start();
            reader = new InputReader();
            reader.DataConverted += new DataConvertedEventHandler(DataConverted_Event);
            serviceThrd = new Thread(reader.Start);
            serviceThrd.Start();
        }
        public void StopAcquisition()
        {
            serviceThrd.Abort();
        }
        public void PauseAcquisition()
        {
            serviceThrd.Suspend();
        }

        public void DataConverted_Event(object sender, SismoData[] e)
        {
            if (DataConverted != null)
                DataConverted(sender, e);
        }

    }
}
