using System;
using System.IO;
using DotnetNMEA.NMEA0183.Messages;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;

namespace DotnetNMEA.NMEA0183
{
    public class NMEA0183Parser : INMEA0183Parser
    {
        private ILogger _logger;
        private ILoggerFactory _loggerFactory;
        public NMEA0183Parser(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<NMEA0183Parser>();
            _loggerFactory = factory;
        }
        
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

        private Nmea0183Message ParseNmeaMessage(MessageType messageType, SpeakerType sType, ReadOnlySpan<char> messageSlice)
        {
            switch (messageType)
            {
                case MessageType.GGA:
                    return new GGAMessage(messageSlice, messageType, sType, _loggerFactory);
                case MessageType.GSA:
                    return new GSAMessage(messageSlice, messageType, sType, _loggerFactory);
                case MessageType.RMC:
                    return new RMCMessage(messageSlice, messageType, sType, _loggerFactory);
                case MessageType.GSV:
                    return new GSVMessage(messageSlice, messageType, sType, _loggerFactory);
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