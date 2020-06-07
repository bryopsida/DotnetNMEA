using System;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;

namespace DotnetNMEA.NMEA0183.Messages
{
    /// <summary>
    /// NMEA GGA Message Object
    /// </summary>
    [MessagePackObject]
    public class GGAMessage : Nmea0183Message
    {
        /// <summary>
        /// UTC Time, does not include date
        /// </summary>
        [Key(2)] 
        public TimeSpan? UTCTime;
        /// <summary>
        /// Latitude
        /// </summary>
        [Key(3)]
        public decimal? Latitude;
        /// <summary>
        /// Whether the latitude is in the northern or southern hemisphere
        /// </summary>
        [Key(4)]
        public NorthSouth NorthSouth;
        /// <summary>
        /// Longitude
        /// </summary>
        [Key(5)]
        public decimal? Longitude;
        /// <summary>
        /// Whether the longitude is in the eastern or western hemisphere
        /// </summary>
        [Key(6)]
        public EastWest EastWest;
        /// <summary>
        /// The GPS Fix quality
        /// </summary>
        [Key(7)]
        public GPSFix FixQuality;
        /// <summary>
        /// Number of satellites in view
        /// </summary>
        [Key(8)]
        public int? SatsInView;
        /// <summary>
        /// Horizontal dilution of precision
        /// </summary>
        [Key(9)]
        public decimal? HDOP;
        /// <summary>
        /// Altitude above mean sea level
        /// </summary>
        [Key(10)]
        public decimal? Altitude;
        /// <summary>
        /// Altitude units
        /// </summary>
        [Key(11)]
        public Units AltitudeUnits;
        /// <summary>
        /// Seperation height from geoid
        /// </summary>
        [Key(12)]
        public decimal? GeoidalSeperation;
        /// <summary>
        /// Units for geoidal seperation
        /// </summary>
        [Key(13)]
        public Units GeoidSeperationUnits;
        /// <summary>
        /// Age of DGPS data
        /// </summary>
        [Key(14)]
        public TimeSpan? AgeOfDGPSData;
        /// <summary>
        /// DGPS Station ID used
        /// </summary>
        [Key(15)]
        public string DGPStationID;

        /// <summary>
        /// Creates a GGA Message object from the NMEA sentence parameter
        /// </summary>
        /// <param name="message">Complete NMEA0183 Sentence</param>
        /// <param name="messageType">Nmea message type
        /// </param>
        /// <param name="sType">The speaker type</param>
        public GGAMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            ExpectedFieldCount = 14;
            ExtractFieldValues(message);
        }

        /// <summary>
        /// Based on index value which is the position in the nmea sentence, extract the value to the create type
        /// and set the correct member value
        /// </summary>
        /// <param name="idx">index</param>
        /// <param name="val">raw value</param>
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    UTCTime = GetTimeSpanFromHHMMSS(val);
                    break;
                case 1:
                    Latitude = GetDecimalDegrees(val);
                    break;
                case 2:
                    NorthSouth = GetNorthSouth(val);
                    break;
                case 3:
                    Longitude = GetDecimalDegrees(val);
                    break;
                case 4:
                    EastWest = GetEastWest(val);
                    break;
                case 5:
                    FixQuality = GetGPSFix(val);
                    break;
                case 6:
                    SatsInView = GetInteger(val);
                    break;
                case 7:
                    HDOP = GetDecimal(val);
                    break;
                case 8:
                    Altitude = GetDecimal(val);
                    break;
                case 9:
                    AltitudeUnits = GetUnits(val);
                    break;
                case 10:
                    GeoidalSeperation = GetDecimal(val);
                    break;
                case 11:
                    GeoidSeperationUnits = GetUnits(val);
                    break;
                case 12:
                    AgeOfDGPSData = GetTimeSpanFromHHMMSS(val);
                    break;
                case 13:
                    DGPStationID = GetString(val);
                    break;

            }
        }
    }
}