using System;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class RMCMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan? UTCTime;
        /// <summary>
        /// 
        /// </summary>
        public ActiveStatus ActiveStatus;
        /// <summary>
        /// 
        /// </summary>
        public decimal? Latitude;
        /// <summary>
        /// 
        /// </summary>
        public NorthSouth NorthSouth;
        /// <summary>
        /// 
        /// </summary>
        public decimal? Longitude;
        /// <summary>
        /// 
        /// </summary>
        public EastWest EastWest;
        /// <summary>
        /// 
        /// </summary>
        public decimal? Knots;
        /// <summary>
        /// 
        /// </summary>
        public decimal? TrackAngle;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date;
        /// <summary>
        /// 
        /// </summary>
        public decimal? MagneticVariation;

        /// <inheritdoc />
        public RMCMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            ExpectedFieldCount = 10;
            ExtractFieldValues(message);
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    UTCTime = GetTimeSpanFromHHMMSS(val);
                    break;
                case 1:
                    ActiveStatus = GetActiveStatus(val);
                    break;
                case 2:
                    Latitude = GetDecimalDegrees(val);
                    break;
                case 3:
                    NorthSouth = GetNorthSouth(val);
                    break;
                case 4:
                    Longitude = GetDecimalDegrees(val);
                    break;
                case 5:
                    EastWest = GetEastWest(val);
                    break;
                case 6:
                    Knots = GetDecimal(val);
                    break;
                case 7:
                    TrackAngle = GetDecimal(val);
                    break;
                case 8:
                    Date = GetDateTimeDDMMYY(val);
                    break;
                case 9:
                    MagneticVariation = GetDecimal(val);
                    break;
            }
        }
    }
}