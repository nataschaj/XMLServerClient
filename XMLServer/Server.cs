using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLib;

namespace XMLServer
{
    public class Server
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
                        
                    //ignorer pls
                    //XmlSerializer xmlserial = new XmlSerializer(typeof(Car));
                    //Car bil = (Car)xmlserial.Deserialize(ns);
                    //xmlserial.Deserialize(sr);
                    //Console.ReadKey();

                    //using (NetworkStream ns = client.GetStream())
                    //using (StreamReader sr = new StreamReader(ns))
                    //using (StreamWriter sw = new StreamWriter(ns))
                    //{
                    //    string line = sr.ReadLine();
                    //    Console.WriteLine(line);
                    //}   /
            }
        }

        private void DoClient(TcpClient socket)
        {
            using (NetworkStream ns = socket.GetStream()) //stream of data for network access.
            using (StreamReader sr = new StreamReader(ns)) //streamReader er from client
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Car)); //xml serialiserer car

                Car bilen = (Car)serializer.Deserialize(sr);
                Console.WriteLine($"From Client as Car object : {bilen}");
            }
        }
    }
}
