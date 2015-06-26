using System;

namespace HttpBench
{
    public class RequestData
    {
        private readonly string _url;
        private readonly int _numberOfRequests;
        private readonly int _numberOfTasks;
        private readonly bool _writeResponseToConsole;

        internal RequestData(string url, int numberOfRequests, int numberOfTasks, bool writeResponseToConsole)
        {
            _url = url;
            _numberOfRequests = numberOfRequests;
            _numberOfTasks = numberOfTasks;
            _writeResponseToConsole = writeResponseToConsole;
        }

        public string Url => _url;

        internal int NumberOfRequests => _numberOfRequests;

        internal int NumberOfTasks => _numberOfTasks;

        internal bool WriteResponseToConsole => _writeResponseToConsole;

        public override bool Equals(object objToBeCompared)
        {
            if (objToBeCompared == null)
                return false;
            if (objToBeCompared is RequestData)
            {
                var objRequestData = (RequestData) objToBeCompared;

                return (objRequestData.Url                      == _url &&
                        objRequestData.NumberOfRequests         == _numberOfRequests &&
                        objRequestData.NumberOfTasks            == _numberOfTasks &&
                        objRequestData.WriteResponseToConsole   == _writeResponseToConsole);
            }
            else
            {
                return false;
            }
        }
    }
}
