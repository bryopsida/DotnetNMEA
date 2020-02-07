using System;
using System.Collections;
using System.Collections.Generic;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{

    public class SatInfo
    {
        public int? SatNum;
        public int? ElevationDegrees;
        public int? AzimuthDegreesToTruee;
        public int? SignalNoiseDB;
    }
    
    public class GSVMessage : Nmea0183Message
    {
        public int? TotalMessages;
        public int? MessageNumber;
        public int? SatsInView;
        public IList<SatInfo> SatInfoCollection;
        
        public GSVMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            ExpectedFieldCount = 3;
            ExtractFieldValues(message);
        }

        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    TotalMessages = GetInteger(val);
                    break;
                case 1:
                    MessageNumber = GetInteger(val);
                    break;
                case 2:
                    SatsInView = GetInteger(val);
                    break;
            }
        }
    }
}