using System;

namespace HttpBench
{
    public class RequestData
    {
        private readonly string _url;
        public string Url => _url;

        private readonly int _numberOfRequests;
        internal int NumberOfRequests => _numberOfRequests;

        private readonly int _numberOfTasks;
        internal int NumberOfTasks => _numberOfTasks;

        private readonly bool _writeResponseToConsole;
        internal bool WriteResponseToConsole => _writeResponseToConsole;


        internal RequestData(string url, int numberOfRequests, int numberOfTasks, bool writeResponseToConsole)
        {
            _url = url;
            _numberOfRequests = numberOfRequests;
            _numberOfTasks = numberOfTasks;
            _writeResponseToConsole = writeResponseToConsole;
        }
        

        public override bool Equals(object objToBeCompared)
        {
            if (!(objToBeCompared is RequestData))
                return false;

            return ((RequestData)objToBeCompared).Url == _url;
        }
    }
}
