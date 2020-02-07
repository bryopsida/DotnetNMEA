using System;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    public class GTDMessage :Nmea0183Message
    {
        public double? TimeDiff1;
        public double? TimeDiff2;
        public double? TimeDiff3;
        public double? TimeDiff4;
        public double? TimeDiff5;
        
        public GTDMessage(
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