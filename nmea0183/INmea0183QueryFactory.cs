using DotnetNMEA.NMEA0183.Types;

namespace DotnetNMEA.NMEA0183
{
    public interface INmea0183QueryFactory
    {
        string CreateQuery(SpeakerType talker, SpeakerType listener, MessageType type);
    }
}