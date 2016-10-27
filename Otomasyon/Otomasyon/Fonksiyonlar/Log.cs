using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Otomasyon.Fonksiyonlar
{
    class Log
    {
        public void HataMesajiYaz(Exception HataMesaji)
        {
            string strLogMessage = "\nMessage : " + HataMesaji.Message +
                "\nSource : " + HataMesaji.Source +
                "\nTarget Site : " + HataMesaji.TargetSite +
                "\nStack Trace : " + HataMesaji.StackTrace;
            string logName = "DenemeLog";
            // EventLogda Hata Mesajının Nereye yazılacagını Belirliyoruz. DenemeLog adında bir Log adı açmıştık.  
            if (!EventLog.SourceExists(logName))
            {
                EventLog.CreateEventSource(logName, logName);
            }
            EventLog log = new EventLog();
            log.Source = logName;
            //Nereye yazılacak? Event Logda DenemeLog Event log dosyasına yazılacak.
            strLogMessage += "\r\n\r\n--------------------------\r\n\r\n" + HataMesaji.ToString();
            // Hata Mesajını alıyoruz.

            log.WriteEntry(strLogMessage, EventLogEntryType.Error, 65534);
            // Hata mesajını log dosyasına yazdırıyoruz.
        }

    }
}
