using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using System.Net.Sockets;
using System.IO;
using System.Xml.Serialization;
using System.Net;

namespace XMLClient
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
            using (StreamWriter sw = new StreamWriter(newstream))
            {
                //XmlSerializer xmlSerial = new XmlSerializer(typeof(Car));

                //xmlSerial.Serialize(sw, publicCar);
                XmlSerializer serializer = new XmlSerializer(typeof(Car));

                StringWriter stringwrit = new StringWriter();
                serializer.Serialize(stringwrit, publicCar);
                
                serializer.Serialize(sw, publicCar);
                sw.Flush();
            }
        }
    }
}

