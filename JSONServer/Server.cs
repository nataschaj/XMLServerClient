using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JSONServer
{
    class Server
    {
        private int port;

        public Server(int port)
        {
            this.port = port;
        }


        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10002);
            server.Start();



            while (true)
            {
                Console.WriteLine("tjekker connection...");

                TcpClient clientSocket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient socket = clientSocket;
                    DoClient(socket);
                });
            }
        }

        private void DoClient(TcpClient socket)
        {
            using (NetworkStream stream = socket.GetStream())
            using (StreamReader sr = new StreamReader(stream)) //streamreader is from client
            {
                String str = sr.ReadLine(); //string from client
                Console.WriteLine($"tekst : {str}"); //text from client

                Car car = JsonConvert.DeserializeObject<Car>(str); //<Car> er "The deserialized object from the JSON string"
                Console.WriteLine($"From Client as car obj : {car}");


            }
        }
    }
}
