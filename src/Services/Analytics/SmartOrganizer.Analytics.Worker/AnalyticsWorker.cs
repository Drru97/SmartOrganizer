using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace SmartOrganizer.Analytics.Worker
{
    public class AnalyticsWorker : RoleEntryPoint
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent _runCompletedEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation($"{nameof(AnalyticsWorker)} is running");

            try
            {
                RunAsync(_cancellationTokenSource.Token).Wait();
            }
            finally
            {
                _runCompletedEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            var result = base.OnStart();

            Trace.TraceInformation($"{nameof(AnalyticsWorker)} has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation($"{nameof(AnalyticsWorker)} is stopping");

            _cancellationTokenSource.Cancel();
            _runCompletedEvent.WaitOne();

            Trace.TraceInformation($"{nameof(AnalyticsWorker)} has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // add some logic here
            }
        }
    }
}
