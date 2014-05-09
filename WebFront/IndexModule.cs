namespace WebFront
{
    using Nancy;
    using System.Text;
    using WebFront.MQ;

    public class IndexModule : NancyModule
    {
        public IndexModule(ServiceBus servicebus)
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Post["/Save"] = parameters =>
            {
                string name = Request.Form["Name"];
                var client = servicebus.GetClient();
                var data = Encoding.UTF8.GetBytes(name);
                client.Send(data, data.Length);
                return HttpStatusCode.OK;
            };
        }
    }
}