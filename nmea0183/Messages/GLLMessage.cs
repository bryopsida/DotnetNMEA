using System;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;

namespace DotnetNMEA.NMEA0183.Messages
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject]
    public class GLLMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public DateTime? UTCTime;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)] 
        public double? Latitude;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)] 
        public NorthSouth NorthSouth;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)] 
        public double? Longitude;
        /// <summary>
        /// 
        /// </summary>
        [Key(6)] 
        public EastWest EastWest;
        /// <summary>
        /// 
        /// </summary>
        [Key(7)] 
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