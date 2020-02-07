using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetNMEA
{
    public struct SerialSettings
    {
        public string PortName;
        public int BaudRate;
        public Parity Parity;
        public int DataBits;
        public StopBits StopBits;
        public Handshake Handshake;
        public int ReadTimeout;
        public int WriteTimeout;
    }

    public class SerialLineReader : INMEA0813Emitter
    {


        public event NMEA0183LineDelegate OnLine;

        private SerialPort _serialPort;
        private Task _readTask;
        private CancellationTokenSource _cancelTokenSource;
        private EventWaitHandle _dataWaitHandle;

        public SerialLineReader(SerialSettings settings)
        {
            _cancelTokenSource = new CancellationTokenSource();
            _dataWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            _serialPort = new SerialPort();
            _serialPort.PortName = settings.PortName;
            _serialPort.BaudRate = settings.BaudRate;
            _serialPort.Parity = settings.Parity;
            _serialPort.DataBits = settings.DataBits;
            _serialPort.StopBits = settings.StopBits;
            _serialPort.Handshake = settings.Handshake;
            _serialPort.ReadTimeout = settings.ReadTimeout;
            _serialPort.WriteTimeout = settings.WriteTimeout;

            _serialPort.DataReceived += (sender, args) => _dataWaitHandle.Set();

            _serialPort.Open();
            _readTask = Read();
        }


        private Task Read()
        {
            return Task.Run(ReadTask);
        }

        private void ReadTask()
        {
            while (!_cancelTokenSource.Token.IsCancellationRequested)
            {
                //check if data is available
                if (_dataWaitHandle.WaitOne(0, false))
                {
                    var result = _serialPort.ReadLine();
                    OnLine?.Invoke(result.AsSpan());
                    _dataWaitHandle.Reset();
                }

                WaitHandle.WaitAny(new WaitHandle[] {_dataWaitHandle, _cancelTokenSource.Token.WaitHandle});
            }
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
            _cancelTokenSource.Cancel();
            _readTask?.Wait();
            _cancelTokenSource?.Dispose();
            _dataWaitHandle?.Dispose();
        }
    }
}