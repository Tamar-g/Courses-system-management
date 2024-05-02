using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is my server");
            ServiceHost host = new ServiceHost(typeof(Service1));
            host.Open();
            Console.Read();

        }
    }
}
