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
        public void Start()
        {
            Car publicCar = new Car();
            publicCar.Model = "Tesla";
            publicCar.RegNo = "XMLCar23";
            publicCar.Color = "Blue";

            TcpListener listener = new TcpListener(IPAddress.Loopback, 10002);
            listener.Start();

            using(TcpClient tc = listener.AcceptTcpClient())
            using (NetworkStream ns = tc.GetStream())
            using (StreamWriter sw = new StreamWriter(ns))
            {
                XmlSerializer xmlSerial = new XmlSerializer(typeof(Car));

                xmlSerial.Serialize(sw, publicCar);
            }
        }
        }
    }
}
