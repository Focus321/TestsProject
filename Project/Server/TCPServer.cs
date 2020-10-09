using Server.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Business_Layer.Models;
using System.Threading.Tasks;

namespace Server
{
    public class TCPServer
    {
        public delegate Task EventStarts();
        public event EventStarts EventStart;

        private TcpListener tcpListener; // сервер для прослушивания
        private List<Client> clients = new List<Client>(); // все подключения
        public Handler Handler { get; set; }
        public TCPServer(SignInHandler signInHandler, SignUpHandler signUpHandler, SignInTeacherHandler signInTeacherHandler, 
            SignUpTeacherHandler signUpTeacherHandler, GetListTestsHandler getListTestsHandler, GetTestHandler getTestHandler,
            GetListTestsTeacherHandler getListTestsTeacherHandler, GetTestTeacherHandler getTestTeacherHandler)
        {
            Handler = signInHandler;
            signInHandler.Successor = signUpHandler;
            signUpHandler.Successor = signInTeacherHandler;
            signInTeacherHandler.Successor = signUpTeacherHandler;
            signUpTeacherHandler.Successor = getListTestsHandler;
            getListTestsHandler.Successor = getTestHandler;
            getTestHandler.Successor = getListTestsTeacherHandler;
            getListTestsTeacherHandler.Successor = getTestTeacherHandler;
        }
        protected internal void AddConnection(Client client) { clients.Add(client); }
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            Client client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                //tcpListener = new TcpListener(IPAddress.Parse("10.0.0.4"), 8888);
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("The server is running. Waiting for connections ...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    Client clientObject = new Client(tcpClient, this);
                    EventStart += clientObject.Process;
                    clients.Add(clientObject);

                    EventStart.Invoke();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal void BroadcastMessage(Command message, string id)
        {
            foreach (var item in clients)
                if (item.Id != id) item.SendCommand(message);
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}