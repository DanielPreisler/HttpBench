using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpBench
{
    internal class ResultData
    {
        private readonly Stopwatch _stopwatch;
        private readonly TimeSpan _smallestTimeToCompleteRequest;
        private readonly TimeSpan _largestTimeToCompleteRequest;
        private readonly int _numberOfRequests;
        private readonly List<string> _resultTextLines;


        internal ResultData(Stopwatch stopwatch, TimeSpan smallestTimeToCompleteRequest, TimeSpan largestTimeToCompleteRequest, int numberOfRequests, List<string> resultTextLines)
        {
            _stopwatch = stopwatch;
            _smallestTimeToCompleteRequest = smallestTimeToCompleteRequest;
            _largestTimeToCompleteRequest = largestTimeToCompleteRequest;
            _numberOfRequests = numberOfRequests;
            _resultTextLines = resultTextLines;
        }

        public override string ToString()
        {
            return "Total: " + _stopwatch.Elapsed +
                   ". Min: " + _smallestTimeToCompleteRequest + ", Max: " + _largestTimeToCompleteRequest +
                   ", Avg: " + _stopwatch.Elapsed.TotalMilliseconds/ _numberOfRequests + " milliseconds.";
        }

        public string GetResultText()
        {
            var stringBuilder = new StringBuilder();

            foreach (var _resultTextLine in _resultTextLines)
                stringBuilder.AppendLine(_resultTextLine);
            

            return stringBuilder.ToString();
        }
    }
}
