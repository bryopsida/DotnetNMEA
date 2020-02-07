using System;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    public class GLCMessage : Nmea0183Message
    {
        public int? GRIMicroSeconds;
        public double? MasterTOAMicroSeconds;
        public string MasterTOASignalStatus;
        public double? TD1MicroSeconds;
        public string TD1SignalStatus;
        public double? TD2MicroSeconds;
        public string TD2SignalStatus;
        public double? TD3MicroSeconds;
        public string TD3SignalStatus;
        public double? TD4MicroSeconds;
        public string TD4SignalStatus;
        public double? TD5MicroSeconds;
        public string TD5SignalStatus;
        
        public GLCMessage(
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