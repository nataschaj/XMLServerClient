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
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 10002);
            server.Start();

          

            while (true)
            {
                using (TcpClient client = server.AcceptTcpClient())
                using (NetworkStream ns = client.GetStream())
                using (StreamReader sr = new StreamReader(ns))
                {


                    Console.WriteLine("tjekker connection...");

                    string line = sr.ReadLine();
                    Console.WriteLine(line);


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
                    //}
                }
            }
        }
    }
}
