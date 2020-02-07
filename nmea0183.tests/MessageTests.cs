using System;
using DotnetNMEA.NMEA0183.Messages;
using DotnetNMEA.NMEA0183.Types;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DotnetNMEA.NMEA0183.tests
{
    public class MessageTests
    {
        [Fact(Skip = "Not Implemented")]
        public void CanParseRMCMessage()
        {
            Assert.True(false);
        }
        
        [Fact]
        public void CanParseGGAMessage()
        {
            var moqLogger = new Mock<ILoggerFactory>();
            INMEA0183Parser parser = new NMEA0183Parser(moqLogger.Object);

            ReadOnlySpan<char> firstMessage = 
                "$GPGGA,215236.000,1231.2006,S,07712.7020,E,1,04,3.8,271.3,M,-22.0,M,,0000*6F";
            GGAMessage mess = parser.Parse(firstMessage) as GGAMessage;
            
            Assert.NotNull(mess);
            Assert.NotNull(mess.Altitude);
            Assert.Equal(new decimal(271.3),mess.Altitude);
            Assert.Equal(Units.Meters, mess.AltitudeUnits);
            Assert.Equal(SpeakerType.GPS, mess.Speaker);
            Assert.Equal(MessageType.GGA, mess.Type);
            Assert.Equal(NorthSouth.South, mess.NorthSouth);
            Assert.Equal(EastWest.East, mess.EastWest);
            Assert.Equal(GPSFix.GpsFix, mess.FixQuality);
            Assert.Null(mess.AgeOfDGPSData);
            Assert.Equal(Units.Meters, mess.GeoidSeperationUnits);
            Assert.Equal(new decimal(-22.0), mess.GeoidalSeperation);
            Assert.Equal(new decimal(3.8), mess.HDOP);
            Assert.Equal(4, mess.SatsInView);
            TimeSpan ts = new TimeSpan(21,52,36);
            Assert.NotNull(mess.UTCTime);
            Assert.Equal(ts, mess.UTCTime);
            Assert.Equal( new decimal(13.073889), mess.Latitude);
            Assert.Equal(new decimal(79.15), mess.Longitude);

        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGSAMessage()
        {
            Assert.True(false);
        }
        
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGSVMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseAAMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseALMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseAPAMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseAPBMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseASDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseBECMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseBODMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseBWCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseBWRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseBWWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDBKMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDPSMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDBTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDCNMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDPTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDSCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDSEMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDSIMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDSRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseDSTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseFSIMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGBSMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGLCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGLLMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGRSMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGSTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGTDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseGXAMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseHDGMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseHDMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseHDTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseHSCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseLCDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseMSKMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseMSSMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseMWDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseMTWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseMWVMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseOLNMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseOSDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseROOMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRMAMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRMBMessage()
        {
            Assert.True(false);
        }

        [Fact(Skip = "Not Implemented")]
        public void CanParseROTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRPMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRSAMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRSDMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseRTEMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseSFIMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseSTNMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseTLLMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseTRFMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseTTMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVBWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVDRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVHWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVLWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVPWMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVTGMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseVWRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseWCVMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseWDCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseWDRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseWNCessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseWPLMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseXDRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseXTEMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseXTRMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseZDAMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseZDLMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseZFOMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParseZTGMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMCMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMEMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMFMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMIMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMMMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMOMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMTMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMVMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePGRMZMessage()
        {
            Assert.True(false);
        }
        
        [Fact(Skip = "Not Implemented")]
        public void CanParsePSLIbMessage()
        {
            Assert.True(false);
        }
    }
}
