using System;
using System.Globalization;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183.Messages
{
    [MessagePackObject]
    public abstract class Nmea0183Message
    {
        [Key(0)]
        public MessageType Type;
        [Key(1)]
        public SpeakerType Speaker;

        protected int ExpectedFieldCount;
        protected ILogger _logger;
        

        protected Nmea0183Message(SpeakerType sType, MessageType mType, ILoggerFactory factory)
        {
            Type = mType;
            Speaker = sType;
            ExpectedFieldCount = 0;
            _logger = factory.CreateLogger<Nmea0183Message>();
        }

        /// <summary>
        /// Crawls over the span extracting sub strings from the span based on comma locations.
        /// Uses the expected field count and length as end checks. When a value is extracted it calls
        /// SetIndexValue in the child class which can map the index to value type and member property.
        /// The intent of this is to be light weight, no external libraries needed for parsing and to also have
        /// minimal heap allocations.
        /// </summary>
        /// <param name="message"></param>
        protected void ExtractFieldValues(ReadOnlySpan<char> message)
        {
            var workingSlice = message;
            var done = false;
            for (int i = 0; i <= ExpectedFieldCount && !done; i++)
            {
                var idx = workingSlice.IndexOf(',');
                done = idx == -1;
                if (!done && workingSlice.Length > 0)
                {
                    if (idx > 0)
                    {
                        var valSlice = workingSlice.Slice(0, idx);
                        SetIndexValue(i, valSlice);
                    }
                   
                    
                    //move the slice along
                    workingSlice = workingSlice.Slice(idx + 1, workingSlice.Length - (idx +1));
                    
                    
                }
            }
        }

        protected decimal? GetDecimalDegrees(ReadOnlySpan<char> slice)
        {
            var idx = slice.IndexOf('.');
            var wholePortion = slice.Slice(0, idx);
            var secondsSlice = slice.Slice(idx + 1);
            ReadOnlySpan<char> degreesSlice;

            int degreeEndIdx = 0;
            
            if (wholePortion.Length > 4)
            {
                degreesSlice = wholePortion.Slice(0, 3);
                degreeEndIdx = 3;
            }
            else
            {
                degreesSlice = wholePortion.Slice(0, 2);
                degreeEndIdx = 2;
            }

            var minutesSlice = wholePortion.Slice(degreeEndIdx);
            if(int.TryParse(degreesSlice.ToString(), out var degrees)
               && int.TryParse(minutesSlice.ToString(), out var minutes) 
               && int.TryParse(secondsSlice.ToString(), out var seconds))
            {
                return (decimal.Round(new decimal(degrees + (minutes / 60.0) + (seconds / 3600.0)), 6, MidpointRounding.AwayFromZero));
            }
            else
            {
                return null;
            }
        }

        protected int? GetInteger(ReadOnlySpan<char> slice)
        {
            if (!int.TryParse(slice.ToString(), out var result))
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        protected NorthSouth GetNorthSouth(ReadOnlySpan<char> slice)
        {
            if (slice.Length == 0)
            {
                return NorthSouth.Unknown;
            }
            
            if (slice[0] == 'N' || slice[0] == 'n')
            {
                return NorthSouth.North;
            }
            else
            {
                return NorthSouth.South;
            }
        }

        protected EastWest GetEastWest(ReadOnlySpan<char> slice)
        {
            if (slice.Length == 0)
            {
                return EastWest.Unknown;
            }
            
            if (slice[0] == 'W' || slice[0] == 'w')
            {
                return EastWest.West;
            }

            return EastWest.East;
        }

        protected string GetString(ReadOnlySpan<char> slice)
        {
            return slice.ToString();
        }

        protected decimal? GetDecimal(ReadOnlySpan<char> slice)
        {
            if (decimal.TryParse(slice.ToString(), out var result))
            {
                return decimal.Round(result, 6, MidpointRounding.AwayFromZero);
            }
            else
            {
                return null;
            }
        }

        protected GPSFix GetGPSFix(ReadOnlySpan<char> slice)
        {
            if (slice[0] == '0')
            {
                return GPSFix.FixtNotAvailable;
            }

            if (slice[0] == '1')
            {
                return GPSFix.GpsFix;
            }

            return GPSFix.DGpsFix;
        }

        protected TimeSpan? GetTimeSpanFromHHMMSS(ReadOnlySpan<char> slice)
        {
            if (TimeSpan.TryParseExact(slice.ToString(), "hhmmss\\.fff", CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        protected double? GetDouble(ReadOnlySpan<char> slice)
        {
            if (double.TryParse(slice.ToString(),  out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        protected Units GetUnits(ReadOnlySpan<char> slice)
        {
            return Units.Meters;
        }

        protected abstract void SetIndexValue(int idx, ReadOnlySpan<char> val);
    }
}