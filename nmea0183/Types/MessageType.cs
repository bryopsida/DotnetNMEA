using System;
using System.Collections.Generic;

namespace DotnetNMEA.NMEA0183.Types
{
    /// <summary>
    /// Lookup used to map strings to message types
    /// </summary>
    public static class MessageTypeLookup
    {
        /// <summary>
        /// GGA Message Type lookup
        /// </summary>
        public const string GGA = "GGA";
        /// <summary>
        /// GSV Message Type Lookup
        /// </summary>
        public const string GSV = "GSV";
        /// <summary>
        /// GLL Message Type Lookup
        /// </summary>
        public const string GLL = "GLL";
        /// <summary>
        /// GRS Message Type Lookup
        /// </summary>
        public const string GRS = "GRS";
        /// <summary>
        /// GST Message Type Lookup
        /// </summary>
        public const string GST = "GST";
        /// <summary>
        /// GBS Message Type Lookup
        /// </summary>
        public const string GBS = "GBS";
        /// <summary>
        /// GLC Message Type Lookup
        /// </summary>
        public const string GLC = "GLC";
        /// <summary>
        /// GTD Message Type Lookup
        /// </summary>
        public const string GTD = "GTD";
        /// <summary>
        /// GXA Message Type Lookup
        /// </summary>
        public const string GXA = "GXA";
        /// <summary>
        /// GSA Message Type Lookup
        /// </summary>
        public const string GSA = "GSA";
        /// <summary>
        /// RMC Message Type Lookup
        /// </summary>
        public const string RMC = "RMC";
    }
    
    /// <summary>
    /// NMEA0183 Message Types
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Waypoint Arrival Alarm Message Type
        /// </summary>
        AAM,
        /// <summary>
        /// GPS Almanac Data Message Type
        /// </summary>
        ALM,
        /// <summary>
        /// Autopilot Sentence A Message Type
        /// </summary>
        APA,
        /// <summary>
        /// Autopilot Sentence B Message Type
        /// </summary>
        APB,
        /// <summary>
        /// Autopilot System Data Message Type
        /// </summary>
        ASD,
        /// <summary>
        /// Bearing And Distance To Waypoint  Dead Reckoning Message Type
        /// </summary>
        BEC,
        /// <summary>
        /// Bearing - Waypoint to Waypoint Message Type
        /// </summary>
        BOD,
        /// <summary>
        /// Bearing and Distance to Waypoint  Latitude, N/S, Longitude, E/W, UTC, Status
        /// </summary>
        BWC,
        /// <summary>
        /// Bearing and Distance to Waypoint  Rhumb Line Latitude, N/S, Longitude, E/W, UTC
        /// Status
        /// </summary>
        BWR,
        /// <summary>
        /// Bearing - Waypoint to Waypoint
        /// </summary>
        BWW,
        /// <summary>
        /// Depth Below Keel
        /// </summary>
        DBK,
        /// <summary>
        /// Depth Below Surface
        /// </summary>
        DBS,
        /// <summary>
        /// Depth Below Transducer
        /// </summary>
        DBT,
        /// <summary>
        /// Decca Position
        /// </summary>
        DCN,
        /// <summary>
        /// Heading - Deviation  Variation
        /// </summary>
        DPT,
        /// <summary>
        /// Digital Selective Calling Information 
        /// </summary>
        DSC,
        /// <summary>
        /// Extended DSC 
        /// </summary>
        DSE,
        /// <summary>
        /// DSC Transponder Initiate
        /// </summary>
        DSI,
        /// <summary>
        /// DSC Transponder Response
        /// </summary>
        DSR,
        /// <summary>
        /// Datum Reference
        /// </summary>
        DTM,
        /// <summary>
        /// Frequency Set Information
        /// </summary>
        FSI,
        /// <summary>
        /// GPS Satellite Fault Detection
        /// </summary>
        GBS,
        /// <summary>
        /// Global Positioning System Fix Data, Time, Position, and fix related data for
        /// a GPS receiver
        /// </summary>
        GGA,
        /// <summary>
        /// Geographic Position, Loran-C
        /// </summary>
        GLC,
        /// <summary>
        /// Geographic Position - Latitue/Longitude
        /// </summary>
        GLL,
        /// <summary>
        /// GPS Range Residuals
        /// </summary>
        GRS,
        /// <summary>
        /// GPS Pseudorange Noise Statistics
        /// </summary>
        GST,
        /// <summary>
        /// GPS DOP and Active Satellites
        /// </summary>
        GSA,
        /// <summary>
        /// Satellites in view
        /// </summary>
        GSV,
        /// <summary>
        /// Geographic Location in Time Differences
        /// </summary>
        GTD,
        /// <summary>
        /// TRANSIT Position - Latitude/Longitude, Location and Time of TRANSIT Fix at Waypoint
        /// 
        /// </summary>
        GXA,
        /// <summary>
        /// Heading - Deviation and Variation
        /// </summary>
        HDG,
        /// <summary>
        /// Heading Magnetic
        /// </summary>
        HDM,
        /// <summary>
        /// Heading True
        /// </summary>
        HDT,
        /// <summary>
        /// Heading Steering Command
        /// </summary>
        HSC,
        /// <summary>
        /// Loran-C Signal Data
        /// </summary>
        LCD,
        /// <summary>
        /// MSK Receiver Interface for DGPS Beacon Receivers
        /// </summary>
        MSK,
        /// <summary>
        /// MSK Receiver Signal Status
        /// </summary>
        MSS,
        /// <summary>
        /// Wind Direction and Speed
        /// </summary>
        MWD,
        /// <summary>
        /// Water Temperature
        /// </summary>
        MTW,
        /// <summary>
        /// Wind Speed and Angle
        /// </summary>
        MWV,
        /// <summary>
        /// Omega Lane Numbers
        /// </summary>
        OLN,
        /// <summary>
        /// Own Ship Data
        /// </summary>
        OSD,
        /// <summary>
        /// Waypoints in Active Route
        /// </summary>
        ROO,
        /// <summary>
        /// Recommended Minimum Navigation Information
        /// </summary>
        RMA,
        /// <summary>
        /// Recommended Minimum Navigation Information
        /// </summary>
        RMB,
        /// <summary>
        /// Recommended Minimum Navigation Information
        /// </summary>
        RMC,
        /// <summary>
        /// Rate of turn
        /// </summary>
        ROT,
        /// <summary>
        /// Revolutions
        /// </summary>
        RPM,
        /// <summary>
        /// Rudder Sensor Angle
        /// </summary>
        RSA,
        /// <summary>
        /// RADAR System Data
        /// </summary>
        RSD,
        /// <summary>
        /// Routes
        /// </summary>
        RTE,
        /// <summary>
        /// Scanning Frequency Information
        /// </summary>
        SFI,
        /// <summary>
        /// Multiple Data ID
        /// </summary>
        STN,
        /// <summary>
        /// Target Latitude and Longitude
        /// </summary>
        TLL,
        /// <summary>
        /// TRANSIT Fix Data
        /// </summary>
        TRF,
        /// <summary>
        /// Tracked Target Message
        /// </summary>
        TTM,
        /// <summary>
        /// Dual Ground Water Speed
        /// </summary>
        VBW,
        /// <summary>
        /// Set and Drift
        /// </summary>
        VDR,
        /// <summary>
        /// Water Speed and Heading
        /// </summary>
        VHW,
        /// <summary>
        /// Distance Traveled through Water
        /// </summary>
        VLW,
        /// <summary>
        /// Speed Measured Parellel to Wind
        /// </summary>
        VPW,
        /// <summary>
        /// Track Made Good and Ground Speed
        /// </summary>
        VTG,
        /// <summary>
        /// Relative Wind Speed and Angle
        /// </summary>
        VWR,
        /// <summary>
        /// Waypoint Closure Velocity
        /// </summary>
        WCV,
        /// <summary>
        /// Distance to Waypoint - Great Circle
        /// </summary>
        WDC,
        /// <summary>
        /// Distance to Waypoint - Rhumb Line
        /// </summary>
        WDR,
        /// <summary>
        /// Distance - Waypoint to Waypoint
        /// </summary>
        WNC,
        /// <summary>
        /// Waypoint Location
        /// </summary>
        WPL,
        /// <summary>
        /// Cross Track Error - Dead Reckoning
        /// </summary>
        XDR,
        /// <summary>
        /// Cross-Track-Error Measured
        /// </summary>
        XTE,
        /// <summary>
        /// Cross-Track-Error Dead Recokoning
        /// </summary>
        XTR,
        /// <summary>
        /// Time and Date - UTC, Day, Month, Year and Local Time Zone
        /// </summary>
        ZDA,
        /// <summary>
        /// Time and Distance to Variable Point
        /// </summary>
        ZDL,
        /// <summary>
        /// UTC and Time from Origin Waypoint
        /// </summary>
        ZFO,
        /// <summary>
        /// UTC and Time to Destination Waypoint
        /// </summary>
        ZTG,
        /// <summary>
        /// Garmin Sensor Configuration Information
        /// </summary>
        PGRMC,
        /// <summary>
        /// Garmin Estimated Position Error
        /// </summary>
        PGRME,
        /// <summary>
        /// Garmin Position Fix Sentence
        /// </summary>
        PGRMF,
        /// <summary>
        /// Garming Sensor Iniitialization Information
        /// </summary>
        PGRMI,
        /// <summary>
        /// Garmin Map Datum
        /// </summary>
        PGRMM,
        /// <summary>
        /// Garmin Output Sentence Enable/Disable
        /// </summary>
        PGRMO,
        /// <summary>
        /// Garmin Sensor Status Information
        /// </summary>
        PGRMT,
        /// <summary>
        /// Garmin 3D Velocity
        /// </summary>
        PGRMV,
        /// <summary>
        /// Garmin Altitude Information
        /// </summary>
        PGRMZ,
        /// <summary>
        /// Starlink Differential GPS Beacon Receiver Control
        /// </summary>
        PSLIB,
        /// <summary>
        /// Unmapped catch all
        /// </summary>
        UNKNOWN
    }
}