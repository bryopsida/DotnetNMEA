using System;
using Boyd.NMEA.NMEA.Types;
using MessagePack;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject]
    public class GSAMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        [Key(2)] 
        public SelectionMode SelectionMode;
        /// <summary>
        /// 
        /// </summary>
        [Key(3)]
        public FixMode Mode;
        /// <summary>
        /// 
        /// </summary>
        [Key(4)]
        public int? Sat1Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(5)]
        public int?  Sat2Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(6)]
        public int?  Sat3Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(7)]
        public int?  Sat4Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(8)]
        public int?  Sat5Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(9)]
        public int?  Sat6Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(10)]
        public int?  Sat7Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(11)]
        public int?  Sat8Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(12)]
        public int?  Sat9Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(13)]
        public int?  Sat10Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(14)]
        public int?  Sat11Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(15)]
        public int?  Sat12Id;
        /// <summary>
        /// 
        /// </summary>
        [Key(16)]
        public double? PDOPMeters;
        /// <summary>
        /// 
        /// </summary>
        [Key(17)]
        public double? HDOPMeters;
        /// <summary>
        /// 
        /// </summary>
        [Key(18)]
        public double? VDOPMeters;

        /// <inheritdoc />
        public GSAMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            ExpectedFieldCount = 17;
            ExtractFieldValues(message);
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            switch (idx)
            {
                case 0:
                    SelectionMode = GetSelectionMode(val);
                    break;
                case 1:
                    Mode = GetFixMode(val);
                    break;
                case 2:
                    Sat1Id = GetInteger(val);
                    break;
                case 3:
                    Sat2Id = GetInteger(val);
                    break;
                case 4:
                    Sat3Id = GetInteger(val);
                    break;
                case 5:
                    Sat4Id = GetInteger(val);
                    break;
                case 6:
                    Sat5Id = GetInteger(val);
                    break;
                case 7:
                    Sat6Id = GetInteger(val);
                    break;
                case 8:
                    Sat7Id = GetInteger(val);
                    break;
                case 9:
                    Sat8Id = GetInteger(val);
                    break;
                case 10:
                    Sat9Id = GetInteger(val);
                    break;
                case 11:
                    Sat10Id = GetInteger(val);
                    break;
                case 12:
                    Sat11Id = GetInteger(val);
                    break;
                case 13:
                    Sat12Id = GetInteger(val);
                    break;
                case 14:
                    PDOPMeters = GetDouble(val);
                    break;
                case 15:
                    HDOPMeters = GetDouble(val);
                    break;
                case 16:
                    VDOPMeters = GetDouble(val);
                    break;

            }
        }
    }
}