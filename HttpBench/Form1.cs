using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HttpGetTest;

namespace HttpBench
{
    public partial class HttpBenchForm : Form
    {
        public HttpBenchForm()
        {
            InitializeComponent();
            txtBxUrl.Text = "http://localhost:8040/?sms=IMEI%3A355457052079650&sno=1263&userid=4560726424";
            txtBxNumberOfRequests.Text = "4";
            txtBxNumberOfTasks.Text = "2";
            chckBxWriteResponseToConsole.Checked = true;

            
        }

       

        private void btnGo_Click(object sender, EventArgs e)
        {
            rchTxtBxOutput.Text = "";
            var mem = new MemoryStream(1000);
            var writer = new StreamWriter(mem);
            Console.SetOut(writer);

            string url = txtBxUrl.Text;
            int numberOfRequests = int.Parse(txtBxNumberOfRequests.Text);
            int numberOfTasks = int.Parse(txtBxNumberOfTasks.Text);
            bool writeResultsToOutput = chckBxWriteResponseToConsole.Checked;

            RequestSender requestSender = new RequestSender(url, numberOfRequests, numberOfTasks, writeResultsToOutput);

            requestSender.SendAllRequests();

            FlushToOutput(writer, mem);

            rchTxtBxOutput.AppendText("************ Done ************");
        }

        private void FlushToOutput(StreamWriter writer, MemoryStream memoryStream )
        {
            writer.Flush();
            string outputText = Encoding.Default.GetString(memoryStream.ToArray());
            rchTxtBxOutput.AppendText(outputText);
        }
    }
}
