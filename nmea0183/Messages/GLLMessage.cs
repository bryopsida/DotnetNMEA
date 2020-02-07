using System;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    public class GLLMessage : Nmea0183Message
    {
        public DateTime? UTCTime;
        public double? Latitude;
        public NorthSouth NorthSouth;
        public double? Longitude;
        public EastWest EastWest;
        public GPSGLLStatus Status;
        
        public GLLMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            
        }

        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            throw new NotImplementedException();
        }
    }
}