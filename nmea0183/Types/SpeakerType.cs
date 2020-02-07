﻿using System.ComponentModel;

namespace DotnetNMEA.NMEA0183.Types
{
    public static class SpeakerTypeLookup
    {
        public const string GPS = "GP";
    }
    public enum SpeakerType 
    {
        [Description("AG")]
        AutoPilotGeneral,
        [Description("AP")]
        AutoPilotMagnetic,
        [Description("CD")]
        CommDigitalSelectiveCalling,
        [Description("CR")]
        CommBeaconReceiver,
        [Description("CS")]
        CommSatellite,
        [Description("CT")]
        CommMFHFTele,
        [Description("CV")]
        CommVHFTele,
        [Description("CX")]
        CommScanningReceiver,
        [Description("DF")]
        DirectionFinder,
        [Description("EC")]
        ECDIS,
        [Description("EP")]
        EPIRB,
        [Description("ER")]
        EngineRoomMonitoring,
        [Description("GP")]
        GPS,
        [Description("HC")]
        HeadingMagneticCompass,
        [Description("HE")]
        HeadingNorthSeekingGyro,
        [Description("HN")]
        HeadingNonNorthSeekingGyro,
        [Description("II")]
        IntegratedInstrumentation,
        [Description("IN")]
        IntegratedNavigation,
        [Description("LC")]
        LoranC,
        [Description("P")]
        Properietary,
        [Description("RA")]
        RadarOrArpa,
        [Description("SD")]
        SounderDepth,
        [Description("SN")]
        ElectronicPositioningSystem,
        [Description("SS")]
        SounderScanning,
        [Description("TI")]
        TurnRateIndicator,
        [Description("VD")]
        VelocityDopplerOther,
        [Description("DM")]
        VelocityMagnetic,
        [Description("VW")]
        VelocityMechanical,
        [Description("WI")]
        WeatherInstruments,
        [Description("YX")]
        Transducer,
        [Description("ZA")]
        AtomicClock,
        [Description("ZC")]
        ChronoMeter,
        [Description("ZQ")]
        QuartzClock,
        [Description("ZV")]
        RadioClock,
        Unknown
    }
}