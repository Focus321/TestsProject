using Newtonsoft.Json;
using Business_Layer.Models;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace Server
{
    public class Client
    {
        protected internal string Id { get; private set; }
        //public string Login { get; set; }
        //public string Password { get; set; }
        //public string Key { get; set; }
        //string userName;
        protected internal NetworkStream Stream { get; private set; }

        TcpClient client;
        public TCPServer server; // объект сервера

        public Client(TcpClient tcpClient, TCPServer serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
        }

        public async Task Process()
        {
            await Task.Run(() =>
            {
                try
                {
                    Stream = client.GetStream();
                    var command = GetMessage();
                    server.Handler.HandlerRequest(command, this);

                    Console.WriteLine("Entered the program");

                    // в бесконечном цикле получаем сообщения от клиента
                    while (true)
                    {
                        try
                        {
                            command = GetMessage();
                            server.Handler.HandlerRequest(command, this);
                        }
                        catch
                        {
                            Console.WriteLine("Left the program");
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    // в случае выхода из цикла закрываем ресурсы
                    server.RemoveConnection(this.Id);
                    Close();
                }
            });
        }

        public void SendCommand(Command command)
        {
            try
            {
                var stream = client.GetStream();
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
                do
                {
                    stream.Write(bytes, 0, bytes.Length);
                } while (stream.DataAvailable);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        // чтение входящего сообщения и преобразование в строку
        private Command GetMessage()
        {
            Command command = new Command();
            byte[] bytes = new byte[20480]; // буфер для получаемых данных
            do
            {
                int countb = Stream.Read(bytes, 0, bytes.Length);
                var str = Encoding.UTF8.GetString(bytes, 0, countb);
                command = JsonConvert.DeserializeObject<Command>(str);
            }
            while (Stream.DataAvailable);

            return command;
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}