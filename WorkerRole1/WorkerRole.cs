using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using WebFront;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable app = null;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("WorkerRole1 entry point called");

            while (true)
            {
                Thread.Sleep(10000);

                Trace.TraceInformation("Working");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            var endPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["SignalREndpoint"];
            string baseUrl = string.Format("{0}://{1}", endPoint.Protocol, endPoint.IPEndpoint);

            Trace.TraceInformation(string.Format("Starting OWIN at {0}", baseUrl));

            app = WebApp.Start<Startup>(new StartOptions(baseUrl));
            return base.OnStart();
        }

        public override void OnStop()
        {
            if(app != null)
                app.Dispose();

            base.OnStop();
        }
    }
}
