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

            for (int i = 0; i < _requestData.NumberOfTasks; i++)
            {
                var task = new Task<ResultData>(TaskMethod);
                tasks.Add(task);
            }
            
            return tasks;
        }

        private ResultData TaskMethod()
        {
            var totalTimeStopwatch = Stopwatch.StartNew();

            TimeSpan largestTimeToCompleteRequest = TimeSpan.Zero;
            TimeSpan smallestTimeToCompleteRequest = TimeSpan.MaxValue;
            List<string> resultTextLines = new List<string>();

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

            totalTimeStopwatch.Stop();

            return new ResultData(totalTimeStopwatch, smallestTimeToCompleteRequest, largestTimeToCompleteRequest, _numberOfRequestsPrTask, resultTextLines);
        }

        private string SendRequest()
        {
            string resultText = "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_requestData.Url);

                var response = (HttpWebResponse)request.GetResponse();

                if (_requestData.WriteResponseToConsole)
                {
                     resultText = GetTextFromStream(response.GetResponseStream());
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
            string text = "";

            if (stream != null)
            {
                var reader = new StreamReader(stream);

                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}
