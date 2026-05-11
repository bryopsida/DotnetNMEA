using System;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class GLLMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UTCTime;
        /// <summary>
        /// 
        /// </summary>
        public double? Latitude;
        /// <summary>
        /// 
        /// </summary>
        public NorthSouth NorthSouth;
        /// <summary>
        /// 
        /// </summary>
        public double? Longitude;
        /// <summary>
        /// 
        /// </summary>
        public EastWest EastWest;
        /// <summary>
        /// 
        /// </summary>
        public GPSGLLStatus Status;

        /// <inheritdoc />
        public GLLMessage(
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