using System;
using DotnetNMEA.NMEA0183.Messages;

namespace DotnetNMEA.NMEA0183
{
    public interface INMEA0183Parser
    {
        Nmea0183Message Parse(ReadOnlySpan<char> messageString);
    }
}