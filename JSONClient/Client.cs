using System;
using System.IO;
using System.Net.Sockets;
using ModelLib;
using Newtonsoft.Json;

namespace JSONClient
{
    public class Client
    {

        private int port;

        public Client(int port)
        {
            this.port = port;
        }
        public void Start()
        {
            Car publicCar = new Car();
            publicCar.Model = "Tesla";
            publicCar.RegNo = "XMLCar23";
            publicCar.Color = "Blue";




            using (TcpClient tclient = new TcpClient("locaholst", 10002))
            using (Stream newstream = tclient.GetStream())
            using (StreamWriter sw = new StreamWriter(newstream)) //toServer 
            {
                String jsonStr = JsonConvert.SerializeObject(publicCar);
                Console.WriteLine($"Client json string: {jsonStr}  + json størrelse: {jsonStr.Length}");

                sw.WriteLine(jsonStr);
                sw.Flush();
            }
        }
    }
}
