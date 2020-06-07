using System;
using Boyd.NMEA.NMEA.Types;
using MessagePack;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject]
    public class RMCMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public TimeSpan? UTCTime;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)] 
        public ActiveStatus ActiveStatus;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)] 
        public decimal? Latitude;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)] 
        public NorthSouth NorthSouth;
        /// <summary>
        /// 
        /// </summary>
        [Key(6)] 
        public decimal? Longitude;
        /// <summary>
        /// 
        /// </summary>
        [Key(7)] 
        public EastWest EastWest;
        /// <summary>
        /// 
        /// </summary>
        [Key(8)] 
        public decimal? Knots;
        /// <summary>
        /// 
        /// </summary>
        [Key(9)] 
        public decimal? TrackAngle;
        /// <summary>
        /// 
        /// </summary>
        [Key(10)] 
        public DateTime? Date;
        /// <summary>
        /// 
        /// </summary>
        [Key(11)] 
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