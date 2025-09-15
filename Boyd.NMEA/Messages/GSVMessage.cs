using System;
using System.Collections.Generic;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA.Messages
{

    /// <summary>
    /// 
    /// </summary>
    public class SatInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int? SatNum;
        /// <summary>
        /// 
        /// </summary>
        public int? ElevationDegrees;
        /// <summary>
        /// 
        /// </summary>
        public int? AzimuthDegreesToTrue;
        /// <summary>
        /// 
        /// </summary>
        public int? SignalNoiseDB;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class GSVMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        public int? TotalMessages;
        /// <summary>
        /// 
        /// </summary>
        public int? MessageNumber;
        /// <summary>
        /// 
        /// </summary>
        public int? SatsInView;
        /// <summary>
        /// 
        /// </summary>
        public IList<SatInfo> SatInfoCollection;

        /// <inheritdoc />
        public GSVMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            ExpectedFieldCount = 3;
            ExtractFieldValues(message);
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    TotalMessages = GetInteger(val);
                    break;
                case 1:
                    MessageNumber = GetInteger(val);
                    break;
                case 2:
                    SatsInView = GetInteger(val);
                    break;
            }
        }
    }
}