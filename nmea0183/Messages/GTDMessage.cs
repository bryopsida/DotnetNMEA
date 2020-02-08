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
    public class GTDMessage :Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public double? TimeDiff1;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)]
        public double? TimeDiff2;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)]
        public double? TimeDiff3;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)]
        public double? TimeDiff4;
        /// <summary>
        /// 
        /// </summary>
        [Key(6)]
        public double? TimeDiff5;

        /// <inheritdoc />
        public GTDMessage(
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