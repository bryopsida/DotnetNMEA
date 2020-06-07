using System;
using Boyd.NMEA.NMEA.Messages;
using Boyd.NMEA.NMEA.Types;
using Xunit;

namespace Boyd.NMEA.NMEA.tests
{
    public class MessageTests
    {
        [Fact]
        public void CanParseRMCMessage()
        {
            INMEA0183Parser parser = new NMEA0183Parser();

            ReadOnlySpan<char> firstMessage = 
                "$GPRMC,215236.000,A,2006.5938,N,09844.6060,W,0.38,343.75,150919,,,A*70";
            RMCMessage mess = parser.Parse(firstMessage) as RMCMessage;
            
            Assert.NotNull(mess);
            Assert.Equal(ActiveStatus.Active, mess.ActiveStatus);
            Assert.Equal(new decimal(0.38), mess.Knots);
            Assert.Equal(new decimal(343.75), mess.TrackAngle);
            Assert.Equal(NorthSouth.North, NorthSouth.North);
            Assert.Equal(EastWest.West, EastWest.West);

            var ts = new TimeSpan(21, 52, 36);
            Assert.Equal(ts, mess.UTCTime);
            Assert.Equal(new decimal(21.749444), mess.Latitude);
            Assert.Equal(new decimal(100.416667), mess.Longitude);
            Assert.Equal(NorthSouth.North, mess.NorthSouth);
            Assert.Equal(EastWest.West, mess.EastWest);

            var date = new DateTime(2019, 9, 15);
            Assert.Equal(date, mess.Date);
            Assert.Null(mess.MagneticVariation);

        }
        
        [Fact]
        public void CanParseGGAMessage()
        {
            INMEA0183Parser parser = new NMEA0183Parser();

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
        
        [Fact]
        public void CanParseGSAMessage()
        {
            INMEA0183Parser parser = new NMEA0183Parser();

            ReadOnlySpan<char> firstMessage = 
                "$GPGSA,M,3,21,32,24,15,,,,,,,,,4.9,3.8,3.2*39";
            GSAMessage mess = parser.Parse(firstMessage) as GSAMessage;
            
            Assert.NotNull(mess);
            Assert.Equal(SelectionMode.Manual, mess.SelectionMode);
            Assert.Equal(FixMode.Fix3D, mess.Mode);
            Assert.Equal(21, mess.Sat1Id);
            Assert.Equal(32, mess.Sat2Id);
            Assert.Equal(24, mess.Sat3Id);
            Assert.Equal(15, mess.Sat4Id);
            Assert.Null(mess.Sat5Id);
            Assert.Null(mess.Sat6Id);
            Assert.Null(mess.Sat7Id);
            Assert.Null(mess.Sat8Id);
            Assert.Null(mess.Sat9Id);
            Assert.Null(mess.Sat10Id);
            Assert.Null(mess.Sat11Id);
            Assert.Null(mess.Sat12Id);
            Assert.Equal(4.9, mess.PDOPMeters);
            Assert.Equal(3.8, mess.HDOPMeters);
            Assert.Equal(3.2, mess.VDOPMeters);
        }
        
        
        [Fact]
        public void CanParseGSVMessage()
        {
            INMEA0183Parser parser = new NMEA0183Parser();

            ReadOnlySpan<char> firstMessage = 
                "$GPGSV,3,1,12,21,68,147,34,32,49,241,23,24,37,073,38,15,13,047,37*76";
            GSVMessage mess = parser.Parse(firstMessage) as GSVMessage;
            Assert.NotNull(mess);
            Assert.Equal(3, mess.TotalMessages);
            Assert.Equal(1, mess.MessageNumber);
            Assert.Equal(12, mess.SatsInView);
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
        public void CanParseMskMessage()
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
