using System;
using System.Collections.Generic;

namespace DotnetNMEA.NMEA0183.Types
{
    public static class MessageTypeLookup
    {
        public const string GGA = "GGA";
        public const string GSV = "GSV";
        public const string GLL = "GLL";
        public const string GRS = "GRS";
        public const string GST = "GST";
        public const string GBS = "GBS";
        public const string GLC = "GLC";
        public const string GTD = "GTD";
        public const string GXA = "GXA";
        public const string GSA = "GSA";
        public const string RMC = "RMC";
    }
    
    public enum MessageType
    {
        AAM,
        ALM,
        APA,
        APB,
        ASD,
        BEC,
        BWC,
        BWR,
        BWW,
        DBK,
        DBS,
        DBT,
        DCN,
        DPT,
        DSC,
        DSE,
        DSI,
        DSR,
        DTM,
        FSI,
        GBS,
        GGA,
        GLC,
        GLL,
        GRS,
        GST,
        GSA,
        GSV,
        GTD,
        GXA,
        HDG,
        HDM,
        HDT,
        HSC,
        LCD,
        MSK,
        MSS,
        MWD,
        MTW,
        MWV,
        OLN,
        OSD,
        ROO,
        RMA,
        RMB,
        RMC,
        ROT,
        RPM,
        RSA,
        RSD,
        RTE,
        SFI,
        STN,
        TLL,
        TRF,
        TTM,
        VBW,
        VDR,
        VHW,
        VLW,
        VPW,
        VTG,
        VWR,
        WCV,
        WDC,
        WDR,
        WNC,
        WPL,
        XDR,
        XTE,
        XTR,
        ZDA,
        ZDL,
        ZFO,
        ZTG,
        PGRMC,
        PGRME,
        PGRMF,
        PGRMI,
        PGRMM,
        PGRMO,
        PGRMT,
        PGRMV,
        PGRMZ,
        PSLIB,
        UNKNOWN
    }
}