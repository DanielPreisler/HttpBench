using HttpBench;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HttpGetTest
{
    internal class RequestSender
    {
        private readonly RequestData _requestData;
        private readonly int _numberOfRequestsPrTask;


        internal RequestSender(RequestData requestData)
        {
            _requestData = requestData;
            _numberOfRequestsPrTask = _requestData.NumberOfRequests / _requestData.NumberOfTasks;
        }


        public List<Task<ResultData>> CreateRequestTasks()
        {
            var tasks = new List<Task<ResultData>>();

            for (int i = 0; i < _requestData.NumberOfTasks; i++) tasks.Add(new Task<ResultData>(TaskMethod));
            
            return tasks;
        }


        private ResultData TaskMethod()
        {
            var totalTime = Stopwatch.StartNew();

            var largestTimeToCompleteRequest = TimeSpan.Zero;
            var smallestTimeToCompleteRequest = TimeSpan.MaxValue;
            var resultTextLines = new List<string>();

            for (int j = 0; j < _numberOfRequestsPrTask; j++)
            {
                var requestStopwatch = Stopwatch.StartNew();
                resultTextLines.Add(SendRequest());
                requestStopwatch.Stop();

                if (requestStopwatch.Elapsed < smallestTimeToCompleteRequest)
                    smallestTimeToCompleteRequest = requestStopwatch.Elapsed;

                if (requestStopwatch.Elapsed > largestTimeToCompleteRequest)
                    largestTimeToCompleteRequest = requestStopwatch.Elapsed;
            }

            totalTime.Stop();

            return new ResultData(totalTime, smallestTimeToCompleteRequest, largestTimeToCompleteRequest, _numberOfRequestsPrTask, resultTextLines);
        }


        private string SendRequest()
        {
            string resultText = "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_requestData.Url);

                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    if (_requestData.WriteResponseToConsole)
                    {
                        resultText = GetTextFromStream(response.GetResponseStream());
                    }
                }
            }
            catch (Exception e)
            {
                resultText = "An error occured: " + e;
            }

            return resultText;
        }


        private string GetTextFromStream(Stream stream)
        {
            if (stream == null) return "";

            return new StreamReader(stream).ReadToEnd();
        }
    }
}
