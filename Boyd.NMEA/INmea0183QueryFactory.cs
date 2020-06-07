using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA
{
    /// <summary>
    /// Used to create query message in proper NMEA0183 format that can be written elsewhere
    /// </summary>
    public interface INmea0183QueryFactory
    {
        /// <summary>
        /// Takes required parameters and builds a NMEA0183 sentence that will query the system 
        /// </summary>
        /// <param name="talker">Who is sending the query</param>
        /// <param name="listener">Who the query is for</param>
        /// <param name="type">The type of message that is being queried</param>
        /// <returns>Complete NMEA0183 Sentence</returns>
        string CreateQuery(SpeakerType talker, SpeakerType listener, MessageType type);
    }
}