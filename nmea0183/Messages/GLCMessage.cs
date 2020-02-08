using System;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject]
    public class GLCMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public int? GRIMicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)] 
        public double? MasterTOAMicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)] 
        public string MasterTOASignalStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)] 
        public double? TD1MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(6)] 
        public string TD1SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(7)] 
        public double? TD2MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(8)] 
        public string TD2SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(9)] 
        public double? TD3MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(10)] 
        public string TD3SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(11)] 
        public double? TD4MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(12)] 
        public string TD4SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(13)] 
        public double? TD5MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        [Key(14)] 
        public string TD5SignalStatus;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <param name="sType"></param>
        /// <param name="loggerFactory"></param>
        public GLCMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            throw new NotImplementedException();
        }
    }
}