using System;
using System.IO.Ports;
using System.Threading;
using CommandLine;
using DotnetNMEA.NMEA0183;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using LogLevel = NLog.LogLevel;

namespace DotnetNMEA
{
    /// <summary>
    /// CLI Options for the CLI tool that takes NMEA0183 raw messages from a source and passes it to the parser to create
    /// NMEA0183 message objects that can be passed/normalized elsewhere
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The serial port name to open, for example COM1 or /dev/ttyS0
        /// </summary>
        [Option('p', "portName", Required = true, HelpText = "The serial port the NMEA device is connected to")]
        public string PortName { get; set; }
        /// <summary>
        /// Serial port baud rate, likely 4800 or 9600 but will vary per device
        /// </summary>
        [Option('b', "baudRate", Required = true, HelpText = "The serial baud rate")]
        public int BaudRate  { get; set; }
        /// <summary>
        /// Serial port parity, EVEN, ODD, NONE. Most likely NONE but can vary per device
        /// </summary>
        [Option('a', "parity", Required = false, Default = Parity.None, HelpText = "The serial port parity")]
        public Parity Parity  { get; set; }
        /// <summary>
        /// Serial port data bits, most likely 8
        /// </summary>
        [Option('d', "dataBits", Required = true, HelpText = "The serial port data bits")]
        public int DataBits  { get; set; }
        /// <summary>
        /// Serial port stop bits, most likely 1
        /// </summary>
        [Option('s', "stopBits", Required = true, HelpText = "The serial port stop bits")]
        public StopBits StopBits  { get; set; }
        /// <summary>
        /// Serial handshake, CTS, RTS, or NONE, most likely None
        /// </summary>
        [Option('h', "handShake", Required = false, Default = Handshake.None, HelpText = "The serial port handshake")]
        public Handshake Handshake  { get; set; }
        /// <summary>
        /// Serial port read timeouts, inner logic attempts to avoid long blocking readings by waiting for data to arrive
        /// before calling read, expects integer value of milliseconds to wait before timing out
        /// </summary>
        [Option('r', "readTimeout", Required = true, HelpText = "The serial port read timeout")]
        public int ReadTimeout  { get; set; }
        /// <summary>
        /// NMEA0183 supports querying, this will set how long the write will block for before timing out. Expects
        /// Integer value of milliseconds before timing out
        /// </summary>
        [Option('w', "writeTimeout", Required = true, HelpText = "The serial port write timeout")]
        public int WriteTimeout  { get; set; }
    }
    
    /// <summary>
    /// Class for taking CLI options, extracting raw NMEA0183 data from the source provided in the CLI options,
    /// using parser to create usable NMEA0183 Message objects and forwarding that data to something that can use it (sinks)
    /// </summary>
    public class DotnetNMEACLI
    {
        private static DotnetNMEACLI _instance;
        private static EventWaitHandle _closeWait = new EventWaitHandle(false, EventResetMode.AutoReset);
        
        private INMEA0813Emitter _lineEmitter;
        private INMEA0183Parser _lineParser;
        private Microsoft.Extensions.Logging.ILogger _logger;
        
        /// <summary>
        /// Constructor for DotnetNMEACLI instace, currently only supports serial sources.
        /// </summary>
        /// <param name="settings">All serial settings needed to open up the serial port and start reading NMEA0183 data</param>
        /// <param name="loggerFactory">Logger Factory used to created logger instances</param>
        public DotnetNMEACLI(SerialSettings settings, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DotnetNMEACLI>();
            _lineParser = new NMEA0183Parser(loggerFactory);
            _lineEmitter = new SerialLineReader(settings);
            _lineEmitter.OnLine += (line) =>
            {
                try
                {
                    var message = _lineParser.Parse(line);
                    _logger.LogInformation("Parsed message with speaker {0} and type {1}", message.Speaker,
                        message.Type);
                }
                catch (Exception e)
                {
                    _logger.LogError("Exception while parsing line: {0}", e.Message);
                }
            };
        }


        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
                .AddTransient<DotnetNMEACLI>() // Runner is the custom class
                .AddLogging(loggingBuilder =>
                {
                    // configure Logging with NLog
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(config);
                })
                .BuildServiceProvider();
        }
        
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Log(LogLevel.Info, "Starting...");
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory()) //From NuGet Package Microsoft.Extensions.Configuration.Json
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var servicesProvider = BuildDi(config);
                using (servicesProvider as IDisposable)
                {
                    ILoggerFactory factory = servicesProvider.GetService<ILoggerFactory>();
                    Parser.Default.ParseArguments<Options>(args)
                        .WithParsed(o =>
                        {
                            //wait for exit signal
                            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
                                e.Cancel = true;
                                _closeWait.Set();
                            };
                    
                            SerialSettings settings = new SerialSettings();
                            settings.Handshake = o.Handshake;
                            settings.BaudRate = o.BaudRate;
                            settings.PortName = o.PortName;
                            settings.DataBits = o.DataBits;
                            settings.Parity = o.Parity;
                            settings.StopBits = o.StopBits;
                            settings.ReadTimeout = o.ReadTimeout;
                            settings.WriteTimeout = o.WriteTimeout;
                            
                            _instance = new DotnetNMEACLI(settings, factory);

                            _closeWait.WaitOne();

                        });
                }
            }
            catch (Exception ex)
            {
                // NLog: catch any exception and log it.
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                logger.Log(LogLevel.Info, "Stopping...");

                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
            
        }
        
    }
}