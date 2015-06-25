using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpGetTest
{
    internal class RequestSender
    {
        private readonly string _url;
        private readonly int _numberOfRequests;
        private readonly int _numberOfTasks;
        private readonly bool _writeResponseToConsole;
        private readonly int _numberOfRequestsPrTask;

        internal RequestSender(string url, int numberOfRequests, int numberOfTasks, bool writeResponseToConsole = false)
        {
            _url = url;
            _numberOfTasks = numberOfTasks;
            _numberOfRequests = numberOfRequests;
            _numberOfRequestsPrTask = _numberOfRequests / _numberOfTasks;
            _writeResponseToConsole = writeResponseToConsole;
        }

        public void SendAllRequests()
        {
            Console.WriteLine("Sending " + _numberOfRequestsPrTask * _numberOfTasks + " requests, using " + _numberOfTasks + " tasks.");

            var tasks = new List<Task>();

            for (int i = 0; i < _numberOfTasks; i++)
            {
                var task = Task.Run(() => { TaskMethod(); });
                tasks.Add(task);
            }

            Console.WriteLine("Waiting for all tasks to complete.");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All tasks are completed.");
        }

        private void TaskMethod()
        {
            var totalTimeStopwatch = Stopwatch.StartNew();

            TimeSpan largestTimeToCompleteRequest = TimeSpan.Zero;
            TimeSpan smallestTimeToCompleteRequest = TimeSpan.MaxValue;

            for (int j = 0; j < _numberOfRequestsPrTask; j++)
            {
                var requestStopwatch = Stopwatch.StartNew();
                SendRequest();
                requestStopwatch.Stop();

                if (requestStopwatch.Elapsed < smallestTimeToCompleteRequest)
                    smallestTimeToCompleteRequest = requestStopwatch.Elapsed;

                if (requestStopwatch.Elapsed > largestTimeToCompleteRequest)
                    largestTimeToCompleteRequest = requestStopwatch.Elapsed;
            }

            totalTimeStopwatch.Stop();
            WriteResultsToConsole(totalTimeStopwatch, smallestTimeToCompleteRequest, largestTimeToCompleteRequest);
        }

        private void SendRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(_url);

            var response = (HttpWebResponse)request.GetResponse();

            if (_writeResponseToConsole)
            {
                WriteStreamToConsole(response.GetResponseStream());
            }
        }

        private void WriteStreamToConsole(Stream stream)
        {
            if (stream != null)
            {
                var reader = new StreamReader(stream);

                Console.WriteLine(reader.ReadToEnd());
            }
        }

        private void WriteResultsToConsole(Stopwatch stopwatch, TimeSpan smallestTimeToCompleteRequest, TimeSpan largestTimeToCompleteRequest)
        {
            Console.WriteLine("Task " + Task.CurrentId + " done.\t" +
                              " Total: " + stopwatch.Elapsed +
                              ". Min: " + smallestTimeToCompleteRequest + ", Max: " + largestTimeToCompleteRequest +
                              ", Avg: " + stopwatch.Elapsed.TotalMilliseconds / _numberOfRequestsPrTask + " milliseconds.");
        }
    }
}
