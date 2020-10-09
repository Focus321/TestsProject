using Newtonsoft.Json;
using Teacher_Program.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Program.Service
{
    public class ConnectService
    {
        private TcpClient _tcpClient;
        public int Id { get; set; }

        public ConnectService() { _tcpClient = new TcpClient(); }
        public async Task Start()
        {
            try { await _tcpClient.ConnectAsync(IPAddress.Parse("169.254.137.211"), 8888); }
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

        public async Task<Command> ReadCommand()
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
                return commandresult;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return null;
        }
    }
}