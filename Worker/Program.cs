using System;
using Microsoft.Owin.Hosting;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8888/"))
            {
                Console.WriteLine("Server running http://localhost:8888/");
                Console.ReadLine();
            }
        }
    }
}
