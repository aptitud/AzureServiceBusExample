using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

namespace WebFront.Hubs
{
    public class SubscriberlistHub : Hub
    {
        private IHubContext _hubs;

        public SubscriberlistHub()
        {
            _hubs = GlobalHost.ConnectionManager.GetHubContext<SubscriberlistHub>();
        }

        public IEnumerable<string> Init()
        {
            return new List<string>
                {
                    "Kalle",
                    "Hobbe"
                };
        }
    }
}