using System.ComponentModel;

namespace Boyd.NMEA.NMEA.Types
{
    /// <summary>
    /// Lookups to match a string to Speaker Type
    /// </summary>
    public static class SpeakerTypeLookup
    {
        /// <summary>
        /// GPS Speaker lookup
        /// </summary>
        public const string GPS = "GP";
    }
    /// <summary>
    /// Speaker Types
    /// </summary>
    public enum SpeakerType 
    {
        /// <summary>
        /// Autopilot General
        /// </summary>
        [Description("AG")]
        AutoPilotGeneral,
        /// <summary>
        /// Autopilot Magnetic
        /// </summary>
        [Description("AP")]
        AutoPilotMagnetic,
        /// <summary>
        /// Digital Selective Calling
        /// </summary>
        [Description("CD")]
        CommDigitalSelectiveCalling,
        /// <summary>
        /// Beacon Receiver
        /// </summary>
        [Description("CR")]
        CommBeaconReceiver,
        /// <summary>
        /// Comm Satellite
        /// </summary>
        [Description("CS")]
        CommSatellite,
        /// <summary>
        /// MF HF Comms
        /// </summary>
        [Description("CT")]
        CommMFHFTele,
        /// <summary>
        /// VHF Telecomm
        /// </summary>
        [Description("CV")]
        CommVHFTele,
        /// <summary>
        /// Comm Scanning Receiver
        /// </summary>
        [Description("CX")]
        CommScanningReceiver,
        /// <summary>
        /// Direction Finder
        /// </summary>
        [Description("DF")]
        DirectionFinder,
        /// <summary>
        /// 
        /// </summary>
        [Description("EC")]
        ECDIS,
        /// <summary>
        /// 
        /// </summary>
        [Description("EP")]
        EPIRB,
        /// <summary>
        /// Engine Room Monitoring
        /// </summary>
        [Description("ER")]
        EngineRoomMonitoring,
        /// <summary>
        /// Global Positioning System
        /// </summary>
        [Description("GP")]
        GPS,
        /// <summary>
        /// Magnetic Heading Compass
        /// </summary>
        [Description("HC")]
        HeadingMagneticCompass,
        /// <summary>
        /// North Seeking Gyro
        /// </summary>
        [Description("HE")]
        HeadingNorthSeekingGyro,
        /// <summary>
        /// Non North Seeking Gyro
        /// </summary>
        [Description("HN")]
        HeadingNonNorthSeekingGyro,
        /// <summary>
        /// Integrated Instrumentation
        /// </summary>
        [Description("II")]
        IntegratedInstrumentation,
        /// <summary>
        /// Integrated Navigation
        /// </summary>
        [Description("IN")]
        IntegratedNavigation,
        /// <summary>
        /// LoranC
        /// </summary>
        [Description("LC")]
        LoranC,
        /// <summary>
        /// Properiatery
        /// </summary>
        [Description("P")]
        Properietary,
        /// <summary>
        /// Radar
        /// </summary>
        [Description("RA")]
        RadarOrArpa,
        /// <summary>
        /// Sounder Depth
        /// </summary>
        [Description("SD")]
        SounderDepth,
        /// <summary>
        /// Electronic Positioning System
        /// </summary>
        [Description("SN")]
        ElectronicPositioningSystem,
        /// <summary>
        /// Sounder Scanning
        /// </summary>
        [Description("SS")]
        SounderScanning,
        /// <summary>
        /// Turn Rate Indicator
        /// </summary>
        [Description("TI")]
        TurnRateIndicator,
        /// <summary>
        /// Velocity Doppler
        /// </summary>
        [Description("VD")]
        VelocityDopplerOther,
        /// <summary>
        /// Velocity Magnetic 
        /// </summary>
        [Description("DM")]
        VelocityMagnetic,
        /// <summary>
        /// Velocity Mechanical
        /// </summary>
        [Description("VW")]
        VelocityMechanical,
        /// <summary>
        /// Weather Instruments
        /// </summary>
        [Description("WI")]
        WeatherInstruments,
        /// <summary>
        /// Transducer
        /// </summary>
        [Description("YX")]
        Transducer,
        /// <summary>
        /// Atomic Clock
        /// </summary>
        [Description("ZA")]
        AtomicClock,
        /// <summary>
        /// ChronoMeter
        /// </summary>
        [Description("ZC")]
        ChronoMeter,
        /// <summary>
        /// Quartz Clock
        /// </summary>
        [Description("ZQ")]
        QuartzClock,
        /// <summary>
        /// Radio Clock
        /// </summary>
        [Description("ZV")]
        RadioClock,
        /// <summary>
        /// Unknown Catch all
        /// </summary>
        Unknown
    }
}