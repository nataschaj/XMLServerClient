using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client klient = new Client();
            klient.Start();
        }
    }
}
