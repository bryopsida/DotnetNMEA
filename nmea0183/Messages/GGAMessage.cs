using System;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    [MessagePackObject]
    public class GGAMessage : Nmea0183Message
    {
        [Key(2)] 
        public TimeSpan? UTCTime;
        [Key(3)]
        public decimal? Latitude;
        [Key(4)]
        public NorthSouth NorthSouth;
        [Key(5)]
        public decimal? Longitude;
        [Key(6)]
        public EastWest EastWest;
        [Key(7)]
        public GPSFix FixQuality;
        [Key(8)]
        public int? SatsInView;
        [Key(9)]
        public decimal? HDOP;
        [Key(10)]
        public decimal? Altitude;
        [Key(11)]
        public Units AltitudeUnits;
        [Key(12)]
        public decimal? GeoidalSeperation;
        [Key(13)]
        public Units GeoidSeperationUnits;
        [Key(14)]
        public TimeSpan? AgeOfDGPSData;
        [Key(15)]
        public string DGPStationID;

        
        public GGAMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType, 
            ILoggerFactory loggerFactory): base(sType, messageType, loggerFactory)
        {
            ExpectedFieldCount = 14;
            ExtractFieldValues(message);
        }

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