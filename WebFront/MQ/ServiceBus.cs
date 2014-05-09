using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetMQ;

namespace WebFront.MQ
{
    public class ServiceBus : IDisposable
    {
        private NetMQContext _context;

        public ServiceBus()
        {
            _context  = NetMQContext.Create();
        }

        public NetMQSocket GetClient()
        {
            var client =  _context.CreateRequestSocket();
            client.Connect("tcp://127.0.0.1:5556");
            return client;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}