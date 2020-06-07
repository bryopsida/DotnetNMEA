using System;

namespace Boyd.NMEA.CLI
{
 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nmeaLine"></param>
    public delegate void NMEA0183LineDelegate(ReadOnlySpan<char> nmeaLine);
    /// <summary>
    /// 
    /// </summary>
    public interface INMEA0813Emitter : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        event NMEA0183LineDelegate OnLine;
    }
}