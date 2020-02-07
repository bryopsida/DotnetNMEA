using System;

namespace DotnetNMEA
{
    public delegate void NMEA0183LineDelegate(ReadOnlySpan<char> nmeaLine);
    public interface INMEA0813Emitter : IDisposable
    {
        event NMEA0183LineDelegate OnLine;
    }
}