using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONClient
{
    class Program
    {
        private const int port = 10002;
        static void Main(string[] args)
        {
            Client klient = new Client(port);
            klient.Start();
        }
    }
}
