using System;
using System.Globalization;
using DotnetNMEA.NMEA0183.Types;
using MessagePack;

namespace DotnetNMEA.NMEA0183.Messages
{
    /// <summary>
    /// Base NMEA0183 Message
    /// </summary>
    [MessagePackObject]
    public abstract class Nmea0183Message
    {
        /// <summary>
        /// Type of message
        /// </summary>
        [Key(0)]
        public MessageType Type;
        /// <summary>
        /// Speaker, what system sent the message
        /// </summary>
        [Key(1)]
        public SpeakerType Speaker;

        /// <summary>
        /// How many fields are expected to be in the nmea sentence, this is set in child classes
        /// </summary>
        protected int ExpectedFieldCount;

        /// <summary>
        /// Set the message type, speaker type, and create the logger instance
        /// </summary>
        /// <param name="sType">Speaker</param>
        /// <param name="mType">Message Type</param>
        protected Nmea0183Message(SpeakerType sType, MessageType mType)
        {
            Type = mType;
            Speaker = sType;
            ExpectedFieldCount = 0;
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
                if (idx == -1)
                {
                    idx = workingSlice.IndexOf('*');
                }
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

        /// <summary>
        /// Convert latitude/longitude from degrees minutes, seconds format to decimal
        /// degrees format with set decimal precision to 6 digits after the decimal point by rounding
        /// </summary>
        /// <param name="slice">the substring of the valu</param>
        /// <returns>decimal degrees</returns>
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

        /// <summary>
        /// Converts string to nullable integer using try parse logic
        /// </summary>
        /// <param name="slice">the sub string value</param>
        /// <returns>integer value</returns>
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

        /// <summary>
        /// Convert the sub string to the enum ActiveStatus
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>ActiveStatus</returns>
        protected ActiveStatus GetActiveStatus(ReadOnlySpan<char> slice)
        {
            switch (slice[0])
            {
                case 'A':
                    return ActiveStatus.Active;
                case 'V':
                    return ActiveStatus.Void;
                default:
                    return ActiveStatus.Unknown;
            }
        }
        /// <summary>
        /// Get North Sourth enum from sub string value
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>NorthSouth</returns>
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
        
        /// <summary>
        /// Gets the EastWest enum from the sub string
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>EastWest</returns>
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

        /// <summary>
        /// Convert Span value to string
        /// </summary>
        /// <param name="slice">sub string span</param>
        /// <returns>string</returns>
        protected string GetString(ReadOnlySpan<char> slice)
        {
            return slice.ToString();
        }

        /// <summary>
        /// Convert the sub string to a nullable decimal
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>nullable decimal converted from string value</returns>
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

        /// <summary>
        /// Get GPS Fix enum from string
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>GPSFix</returns>
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

        /// <summary>
        /// Convert a time value in the hhmmss.fff format into a timespan
        /// </summary>
        /// <param name="slice">substring value</param>
        /// <returns>TimeSpan</returns>
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

        /// <summary>
        /// Get a double from the substring value
        /// </summary>
        /// <param name="slice">substring value</param>
        /// <returns>converted value if successful null otherwise</returns>
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

        /// <summary>
        /// Convert the character to the units enum
        /// </summary>
        /// <param name="slice">Sub string value</param>
        /// <returns>Units</returns>
        protected Units GetUnits(ReadOnlySpan<char> slice)
        {
            return Units.Meters;
        }

        /// <summary>
        /// Get the fix mode
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>FixMode</returns>
        protected FixMode GetFixMode(ReadOnlySpan<char> slice)
        {
            switch (slice[0])
            {
                case '2':
                    return FixMode.Fix2D;
                case '3':
                    return FixMode.Fix3D;
                default:
                    return FixMode.NotAvailable;
            }
        }
        
        /// <summary>
        /// Convert string into a SelectionMode enum
        /// </summary>
        /// <param name="slice">sub string value</param>
        /// <returns>SelectionMode</returns>
        protected SelectionMode GetSelectionMode(ReadOnlySpan<char> slice)
        {
            switch (slice[0])
            {
                case 'M':
                    return SelectionMode.Manual;
                case 'A':
                    return SelectionMode.Automatic;
                default:
                    return SelectionMode.Unknown;
            }
        }

        /// <summary>
        /// Get a date time object with just the date from a string in the format of ddMMYY 
        /// </summary>
        /// <param name="val">substring value</param>
        /// <returns>DateTime if it can be parsed, null otherwise</returns>
        protected DateTime? GetDateTimeDDMMYY(ReadOnlySpan<char> val)
        {
            if (DateTime.TryParseExact(val.ToString(), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implemented in child classes. Child classes have the context of knowing the mapping
        /// of index value to member value and type
        /// </summary>
        /// <param name="idx">index of the value in the nmea sentence</param>
        /// <param name="val">raw value</param>
        protected abstract void SetIndexValue(int idx, ReadOnlySpan<char> val);
    }
}