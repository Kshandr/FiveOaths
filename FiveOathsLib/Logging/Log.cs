using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiveOathsLib.Data;

namespace FiveOathsLib.Logging
{
    public class Log
    {
        /*
        private DateTime _loggingDate;
        private int _sourceCharacterID;
        private int _sourcePlayerID;
        private int _destinationCharacterID;
        private int _destinationPlayerID;
        private string _action;
        */

        public static void Write(int sourceCharacterID, int sourcePlayerID, int destinationCharacterID, int destinationPlayerID)
        {
            
            
            
        }

        public static void Write(int sourcePlayerID, string action)
        {
            logfile myLog = new logfile();
            myLog.sourceplayer = sourcePlayerID;
            myLog.logdate = DateTime.Now;
            myLog.action = action;

            myLog.Save();
        }

        public static List<string> ReturnLogReport()
        {
            List<string> myList = new List<string>();

            foreach(logfile myLog in logfile.All())
            {
                myList.Add(myLog.logdate + "," + myLog.sourceplayer.ToString() + "," + myLog.action);
            }

            return myList;
        }
    }
}
