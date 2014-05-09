using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetMQ;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Worker.Hubs;

namespace Worker.MQ
{
    public class ServiceBus : IDisposable
    {
        private NetMQSocket _server;
        private NetMQContext _context;

        public ServiceBus()
        {
            _context = NetMQContext.Create();
            _server = _context.CreateResponseSocket();
            var endpoint = "tcp://127.0.0.1:5556";
            _server.Bind(endpoint);
            Thread.Sleep(100);

                var str = _server.ReceiveString();

                if (!string.IsNullOrEmpty(str))
                {
                    var hub = GlobalHost.ConnectionManager.GetHubContext<SubscriberlistHub>();
                    hub.Clients.All.addNewSubscriber(str);
                }

                Thread.Sleep(1000);
        }

        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
            }

            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
