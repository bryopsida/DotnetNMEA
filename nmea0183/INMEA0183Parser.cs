using System;
using DotnetNMEA.NMEA0183.Messages;

namespace DotnetNMEA.NMEA0183
{
    /// <summary>
    /// Interface contract for classes that can parse NMEA messages and return NMEA messages
    /// </summary>
    public interface INMEA0183Parser
    {
        /// <summary>
        /// Parse the raw NMEA0183 sentence and return a NMEA message object
        /// </summary>
        /// <param name="messageString">complete NMEA0183 Sentence</param>
        /// <returns>parsed NMEA message object</returns>
        Nmea0183Message Parse(ReadOnlySpan<char> messageString);

        /// <summary>
        /// Parse the raw NMEA0183 sentence and return a NMEA message object
        /// </summary>
        /// <param name="messageString">complete NMEA0183 Sentence in string data type</param>
        /// <returns>parsed NMEA message object</returns>
        Nmea0183Message Parse(string messageString);
        
        /// <summary>
        /// Parse the raw NMEA0183 sentence and return a NMEA message object
        /// </summary>
        /// <param name="messageBytes">NMEA sentence in byte form</param>
        /// <returns>parsed NMEA message object</returns>
        Nmea0183Message Parse(byte[] messageBytes);
    }
}