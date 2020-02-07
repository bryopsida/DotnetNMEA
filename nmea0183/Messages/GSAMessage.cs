using System;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    public class GSAMessage : Nmea0183Message
    {
        public string SelectionMode;
        public string Mode;
        public string Sat1Id;
        public string Sat2Id;
        public string Sat3Id;
        public string Sat4Id;
        public string Sat5Id;
        public string Sat6Id;
        public string Sat7Id;
        public string Sat8Id;
        public string Sat9Id;
        public string Sat10Id;
        public string Sat11Id;
        public string Sat12Id;
        public double? PDOPMeters;
        public double? HDOPMeters;
        public double? VDOPMeters;
        
        public GSAMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            ExpectedFieldCount = 17;
            ExtractFieldValues(message);
        }

        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    SelectionMode = GetString(val);
                    break;
                case 1:
                    Mode = GetString(val);
                    break;
                case 2:
                    Sat1Id = GetString(val);
                    break;
                case 3:
                    Sat2Id = GetString(val);
                    break;
                case 4:
                    Sat3Id = GetString(val);
                    break;
                case 5:
                    Sat4Id = GetString(val);
                    break;
                case 6:
                    Sat5Id = GetString(val);
                    break;
                case 7:
                    Sat6Id = GetString(val);
                    break;
                case 8:
                    Sat7Id = GetString(val);
                    break;
                case 9:
                    Sat8Id = GetString(val);
                    break;
                case 10:
                    Sat9Id = GetString(val);
                    break;
                case 11:
                    Sat10Id = GetString(val);
                    break;
                case 12:
                    Sat11Id = GetString(val);
                    break;
                case 13:
                    Sat12Id = GetString(val);
                    break;
                case 14:
                    PDOPMeters = GetDouble(val);
                    break;
                case 15:
                    HDOPMeters = GetDouble(val);
                    break;
                case 16:
                    VDOPMeters = GetDouble(val);
                    break;

            }
        }
    }
}