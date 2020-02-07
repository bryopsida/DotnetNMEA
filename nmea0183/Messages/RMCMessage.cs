using System;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    public class RMCMessage : Nmea0183Message
    {
        public TimeSpan? UTCTime;
        public ActiveStatus ActiveStatus;
        public decimal? Latitude;
        public decimal? Longitude;
        public decimal? Knots;
        public decimal? TrackAngle;
        public DateTime? Date;
        public decimal? MagneticVariation;

        public RMCMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            ExpectedFieldCount = 8;
            ExtractFieldValues(message);
        }

        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    UTCTime = GetTimeSpanFromHHMMSS(val);
                    break;
                case 1:
                    break;
                case 2:
                    Latitude = GetDecimalDegrees(val);
                    break;
                case 3:
                    Longitude = GetDecimalDegrees(val);
                    break;
                case 4:
                    Knots = GetDecimal(val);
                    break;
                case 5:
                    TrackAngle = GetDecimal(val);
                    break;
                case 6:
                    break;
                case 7:
                    MagneticVariation = GetDecimal(val);
                    break;
            }
        }
    }
}