using System;
using System.Text;
using Boyd.NMEA.NMEA.Messages;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA
{
    /// <summary>
    /// Simple parser for NMEA0183 sentences
    /// </summary>
    public class NMEA0183Parser : INMEA0183Parser
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NMEA0183Parser()
        {
        }
        
        /// <summary>
        /// Parse the NMEA0183 sentence into a NMEA message object
        /// </summary>
        /// <param name="messageString">the complete NMEA0183 sentence</param>
        /// <returns>A NMEA message object with the data extracted so it's in a readily usable format</returns>
        /// <exception cref="ArgumentException">Thrown if a bad sentence is passed in</exception>
        public Nmea0183Message Parse(ReadOnlySpan<char> messageString)
        {
            if (messageString == null)
            {
                throw new ArgumentException("NMEA Message cannot be null");
            }

            int stopOfSpeakerAndMessageIdx = messageString.IndexOf(',');
            if (stopOfSpeakerAndMessageIdx == -1)
            {
                throw new ArgumentException("Not a valid NMEA Message");
            }

            var startSlice = messageString.Slice(1, stopOfSpeakerAndMessageIdx - 1);
            var speakerSlice = startSlice.Slice(0, 2);
            var messageTypeSlice = startSlice.Slice(2, startSlice.Length-2);
            var messageContentSlice = messageString.Slice(stopOfSpeakerAndMessageIdx + 1);

            var messageType = GetMessageType(messageTypeSlice);
            var speakerType = GetSpeakerType(speakerSlice);

            Nmea0183Message message = ParseNmeaMessage(messageType, speakerType, messageContentSlice);
            return message;
        }

                
        /// <summary>
        /// Parse the NMEA0183 sentence into a NMEA message object
        /// </summary>
        /// <param name="messageString">the complete NMEA0183 sentence</param>
        /// <returns>A NMEA message object with the data extracted so it's in a readily usable format</returns>
        /// <exception cref="ArgumentException">Thrown if a bad sentence is passed in</exception>
        public Nmea0183Message Parse(string messageString)
        {
            return Parse(new ReadOnlySpan<char>(messageString.ToCharArray()));
        }
        /// <summary>
        /// Parse the NMEA0183 sentence into a NMEA message object
        /// </summary>
        /// <param name="messageBytes">the complete NMEA0183 sentence in raw bytes, expects UTF8 encoding</param>
        /// <returns>A NMEA message object with the data extracted so it's in a readily usable format</returns>
        /// <exception cref="ArgumentException">Thrown if a bad sentence is passed in</exception>
        public Nmea0183Message Parse(byte[] messageBytes)
        {
            return Parse(new ReadOnlySpan<char>(Encoding.UTF8.GetChars(messageBytes)));
        }

        private Nmea0183Message ParseNmeaMessage(MessageType messageType, SpeakerType sType, ReadOnlySpan<char> messageSlice)
        {
            switch (messageType)
            {
                case MessageType.GGA:
                    return new GGAMessage(messageSlice, messageType, sType);
                case MessageType.GSA:
                    return new GSAMessage(messageSlice, messageType, sType);
                case MessageType.RMC:
                    return new RMCMessage(messageSlice, messageType, sType);
                case MessageType.GSV:
                    return new GSVMessage(messageSlice, messageType, sType);
                default:
                    throw new NotSupportedException($"Message type {messageType} not supported");
            }
        }

        private bool SpanEqualsString(ReadOnlySpan<char> span, string str)
        {
            if (span.Length != str.Length)
            {
                return false;
            }

            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != str[i])
                {
                    return false;
                }
            }

            return true;
        }

        private MessageType GetMessageType(ReadOnlySpan<char> messageTypeSlice)
        {
            if (SpanEqualsString(messageTypeSlice, MessageTypeLookup.GGA))
            {
                return MessageType.GGA;
            }
            else if (SpanEqualsString(messageTypeSlice, MessageTypeLookup.GSV))
            {
                return MessageType.GSV;
            }
            else if (SpanEqualsString(messageTypeSlice, MessageTypeLookup.GSA))
            {
                return MessageType.GSA;
            }
            else if (SpanEqualsString(messageTypeSlice, MessageTypeLookup.RMC))
            {
                return MessageType.RMC;
            }
            else
            {
                return MessageType.UNKNOWN;
            }
        }

        private SpeakerType GetSpeakerType(ReadOnlySpan<char> speakerTypeSlice)
        {
            if (SpanEqualsString(speakerTypeSlice, SpeakerTypeLookup.GPS))
            {
                return SpeakerType.GPS;
            }
            else
            {
                return SpeakerType.Unknown;
            }
        }
    }
}