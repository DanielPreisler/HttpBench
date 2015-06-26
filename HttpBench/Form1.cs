using HttpGetTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
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
            return new List<RequestData>() {new RequestData("http://localhost:8040/?sms=IMEI%3A355457052079650&sno=1263&userid=4660726424", 1,1,true), new RequestData("url2", 2, 2, true) };
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            rchTxtBxOutput.Text = "";
            var mem = new MemoryStream(1000);
            var writer = new StreamWriter(mem);
            Console.SetOut(writer);

            var requestDataFromForm = GetRequestDataFromForm();

            RequestSender requestSender = new RequestSender(requestDataFromForm);

            requestSender.SendAllRequests();

            FlushToOutput(writer, mem);

            rchTxtBxOutput.AppendText("************ Done ************");

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
            RequestData requestDataFromForm = GetRequestDataFromForm();

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


        private void FlushToOutput(StreamWriter writer, MemoryStream memoryStream )
        {
            writer.Flush();
            string outputText = Encoding.Default.GetString(memoryStream.ToArray());
            rchTxtBxOutput.AppendText(outputText);
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
