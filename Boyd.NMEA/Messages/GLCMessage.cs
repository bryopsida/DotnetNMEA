using System;
using Boyd.NMEA.NMEA.Types;

namespace Boyd.NMEA.NMEA.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class GLCMessage : Nmea0183Message
    {
        /// <summary>
        /// 
        /// </summary>
        public int? GRIMicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public double? MasterTOAMicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string MasterTOASignalStatus;
        /// <summary>
        /// 
        /// </summary>
        public double? TD1MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string TD1SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        public double? TD2MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string TD2SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        public double? TD3MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string TD3SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        public double? TD4MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string TD4SignalStatus;
        /// <summary>
        /// 
        /// </summary>
        public double? TD5MicroSeconds;
        /// <summary>
        /// 
        /// </summary>
        public string TD5SignalStatus;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <param name="sType"></param>
        public GLCMessage(
            ReadOnlySpan<char> message,
            MessageType messageType, 
            SpeakerType sType): base(sType, messageType)
        {
            
        }

        /// <inheritdoc />
        protected override void SetIndexValue(int idx, ReadOnlySpan<char> val)
        {
            throw new NotImplementedException();
        }
    }
}