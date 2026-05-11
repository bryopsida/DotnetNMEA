using System;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class GTDMessage :Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        public double? TimeDiff1;
        /// <summary>
        /// 
        /// </summary>
        public double? TimeDiff2;
        /// <summary>
        /// 
        /// </summary>
        public double? TimeDiff3;
        /// <summary>
        /// 
        /// </summary>
        public double? TimeDiff4;
        /// <summary>
        /// 
        /// </summary>
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