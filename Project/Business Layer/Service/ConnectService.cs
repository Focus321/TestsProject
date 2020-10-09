using Business_Layer.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public class ConnectService
    {
        private TcpClient _tcpClient;

        public delegate Task EventResiveCommand(Command command);
        public event EventResiveCommand CommandReciveEvent;

        public ConnectService() { _tcpClient = new TcpClient(); }
        public void Start()
        {
            try { _tcpClient.Connect(new IPEndPoint(IPAddress.Parse("169.254.137.211"), 8888)); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void SendCommand(Command command)
        {
            try
            {
                var stream = _tcpClient.GetStream();
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        public async Task ReadCommand()
        {
            while (true)
            {
                try
                {
                    var stream = _tcpClient.GetStream();
                    Command commandresult = new Command();
                    do
                    {
                        var bytes = new byte[20480];
                        if (stream.CanRead == true)
                        {
                            int countb = await stream.ReadAsync(bytes, 0, bytes.Length);
                            var str = Encoding.UTF8.GetString(bytes, 0, countb);
                            commandresult = JsonConvert.DeserializeObject<Command>(str);
                        }
                    } while (stream.DataAvailable);
                    CommandReciveEvent?.Invoke(commandresult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
            }
        }
    }
}