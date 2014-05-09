namespace WebFront
{
    using Microsoft.AspNet.SignalR;
    using Nancy;
    using WebFront.Hubs;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Post["/Save"] = parameters =>
            {
                string name = Request.Form["Name"];
                var hub = GlobalHost.ConnectionManager.GetHubContext<SubscriberlistHub>();
                hub.Clients.All.addNewSubscriber(name);
                return HttpStatusCode.OK;
            };
        }
    }
}