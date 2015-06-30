using HttpGetTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpBench
{
    public partial class HttpBenchForm : Form
    {
        private readonly List<RequestData> latestUsedRequestData;

        public HttpBenchForm()
        {
            InitializeComponent();

            latestUsedRequestData = GetLatestUsedRequestData();
            cmboBxUrls.DataSource = latestUsedRequestData;
            cmboBxUrls.DisplayMember = "Url";
            cmboBxUrls.SelectedIndex = 0;
        }

        private List<RequestData> GetLatestUsedRequestData()
        {
            return new List<RequestData>() { new RequestData("http://testservices200.prod.local:8040/?sms=IMEI%3A355457052079650&sno=1263&userid=4560726424", 1, 1, true),
                                             new RequestData("http://localhost:8040/?sms=IMEI%3A355457052079650&sno=1263&userid=4560726424", 1, 1, true) };
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            rchTxtBxOutput.Text = "";

            var requestDataFromForm = GetRequestDataFromForm();

            int numberOfRequestsPrTask = requestDataFromForm.NumberOfRequests / requestDataFromForm.NumberOfTasks;

            rchTxtBxOutput.AppendText("Sending " + numberOfRequestsPrTask * requestDataFromForm.NumberOfTasks + " requests, using " + requestDataFromForm.NumberOfTasks + " tasks.");

            var requestTasks = new RequestSender(requestDataFromForm).CreateRequestTasks();

            foreach (var requestTask in requestTasks)
            {
                requestTask.Start();
            }

            var output = "Waiting for all tasks to complete.\n";

            Task.WaitAll(requestTasks.ToArray());

            output +=("All tasks are completed.\n");

            var resultData = requestTasks.Select(someTask => someTask.Result).ToList();
            string responses = "";

            foreach (var data in resultData)
            {
                output += data + "\n";
                responses += data.GetResultText();
            }

            if (chckBxWriteResponseToConsole.Checked)
            {
                output += "************ responses: ************\n";

                output += responses;
            }

            output += "************ Done ************\n";
            
            rchTxtBxOutput.AppendText(output);

            UpdateListOfRecentlyUsedRequests();
        }


        private RequestData GetRequestDataFromForm()
        {
            string url = cmboBxUrls.Text;
            int numberOfRequests = int.Parse(txtBxNumberOfRequests.Text);
            int numberOfTasks = int.Parse(txtBxNumberOfTasks.Text);
            bool writeResultsToOutput = chckBxWriteResponseToConsole.Checked;

            var requestData = new RequestData(url, numberOfRequests, numberOfTasks, writeResultsToOutput);

            return requestData;
        }


        private void UpdateListOfRecentlyUsedRequests()
        {
            var requestDataFromForm = GetRequestDataFromForm();

            if (!latestUsedRequestData.Contains(requestDataFromForm) && !string.IsNullOrEmpty(requestDataFromForm.Url))
            {
                if (latestUsedRequestData.Count > 10)
                {
                    latestUsedRequestData.RemoveAt(0);
                }

                latestUsedRequestData.Insert(0, requestDataFromForm);
                cmboBxUrls.DataSource = null;
                cmboBxUrls.DataSource = latestUsedRequestData;
                cmboBxUrls.DisplayMember = "Url";
                cmboBxUrls.SelectedIndex = 0;
            }
        }

        private void cmboBxUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboBxUrls.SelectedIndex >= 0)
            {
                var requestData = (cmboBxUrls.DataSource as List<RequestData>)[cmboBxUrls.SelectedIndex];
                txtBxNumberOfRequests.Text = requestData.NumberOfRequests.ToString();
                txtBxNumberOfTasks.Text = requestData.NumberOfTasks.ToString();
                chckBxWriteResponseToConsole.Checked = requestData.WriteResponseToConsole;
            }
        }
    }
}
