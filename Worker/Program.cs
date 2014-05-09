using System;
using Microsoft.Owin.Hosting;
using Worker.MQ;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBus bus;
            using (WebApp.Start<Startup>("http://localhost:8888/"))
            {
                Console.WriteLine("Server running http://localhost:8888/");
                bus = new ServiceBus();
                Console.ReadLine();
            }
            bus.Dispose();
        }
    }
}
