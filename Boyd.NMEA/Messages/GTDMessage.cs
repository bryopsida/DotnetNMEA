using System;
using Boyd.NMEA.NMEA.Types;
using MessagePack;

namespace Boyd.NMEA.NMEA.Messages
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
            SpeakerType sType): base(sType, messageType)
        {
            
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            throw new NotImplementedException();
        }
    }
}