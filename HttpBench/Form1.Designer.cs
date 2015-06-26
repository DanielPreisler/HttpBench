namespace HttpBench
{
    partial class HttpBenchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtBxNumberOfRequests = new System.Windows.Forms.TextBox();
            this.lblTotalNumberOfRequests = new System.Windows.Forms.Label();
            this.txtBxNumberOfTasks = new System.Windows.Forms.TextBox();
            this.lblNumberOfTasks = new System.Windows.Forms.Label();
            this.chckBxWriteResponseToConsole = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.rchTxtBxOutput = new System.Windows.Forms.RichTextBox();
            this.cmboBxUrls = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(13, 40);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "URL:";
            // 
            // txtBxNumberOfRequests
            // 
            this.txtBxNumberOfRequests.Location = new System.Drawing.Point(12, 110);
            this.txtBxNumberOfRequests.Name = "txtBxNumberOfRequests";
            this.txtBxNumberOfRequests.Size = new System.Drawing.Size(54, 20);
            this.txtBxNumberOfRequests.TabIndex = 2;
            // 
            // lblTotalNumberOfRequests
            // 
            this.lblTotalNumberOfRequests.AutoSize = true;
            this.lblTotalNumberOfRequests.Location = new System.Drawing.Point(9, 94);
            this.lblTotalNumberOfRequests.Name = "lblTotalNumberOfRequests";
            this.lblTotalNumberOfRequests.Size = new System.Drawing.Size(127, 13);
            this.lblTotalNumberOfRequests.TabIndex = 3;
            this.lblTotalNumberOfRequests.Text = "Total number of requests:";
            // 
            // txtBxNumberOfTasks
            // 
            this.txtBxNumberOfTasks.Location = new System.Drawing.Point(12, 162);
            this.txtBxNumberOfTasks.Name = "txtBxNumberOfTasks";
            this.txtBxNumberOfTasks.Size = new System.Drawing.Size(54, 20);
            this.txtBxNumberOfTasks.TabIndex = 4;
            // 
            // lblNumberOfTasks
            // 
            this.lblNumberOfTasks.AutoSize = true;
            this.lblNumberOfTasks.Location = new System.Drawing.Point(13, 146);
            this.lblNumberOfTasks.Name = "lblNumberOfTasks";
            this.lblNumberOfTasks.Size = new System.Drawing.Size(84, 13);
            this.lblNumberOfTasks.TabIndex = 5;
            this.lblNumberOfTasks.Text = "Number of tasks";
            // 
            // chckBxWriteResponseToConsole
            // 
            this.chckBxWriteResponseToConsole.AutoSize = true;
            this.chckBxWriteResponseToConsole.Location = new System.Drawing.Point(12, 198);
            this.chckBxWriteResponseToConsole.Name = "chckBxWriteResponseToConsole";
            this.chckBxWriteResponseToConsole.Size = new System.Drawing.Size(149, 17);
            this.chckBxWriteResponseToConsole.TabIndex = 6;
            this.chckBxWriteResponseToConsole.Text = "Write response to console";
            this.chckBxWriteResponseToConsole.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 242);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // rchTxtBxOutput
            // 
            this.rchTxtBxOutput.Location = new System.Drawing.Point(12, 301);
            this.rchTxtBxOutput.Name = "rchTxtBxOutput";
            this.rchTxtBxOutput.Size = new System.Drawing.Size(940, 400);
            this.rchTxtBxOutput.TabIndex = 8;
            this.rchTxtBxOutput.Text = "";
            // 
            // cmboBxUrls
            // 
            this.cmboBxUrls.FormattingEnabled = true;
            this.cmboBxUrls.Location = new System.Drawing.Point(12, 56);
            this.cmboBxUrls.Name = "cmboBxUrls";
            this.cmboBxUrls.Size = new System.Drawing.Size(607, 21);
            this.cmboBxUrls.TabIndex = 9;
            this.cmboBxUrls.SelectedIndexChanged += new System.EventHandler(this.cmboBxUrls_SelectedIndexChanged);
            // 
            // HttpBenchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 731);
            this.Controls.Add(this.cmboBxUrls);
            this.Controls.Add(this.rchTxtBxOutput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.chckBxWriteResponseToConsole);
            this.Controls.Add(this.lblNumberOfTasks);
            this.Controls.Add(this.txtBxNumberOfTasks);
            this.Controls.Add(this.lblTotalNumberOfRequests);
            this.Controls.Add(this.txtBxNumberOfRequests);
            this.Controls.Add(this.lblUrl);
            this.Name = "HttpBenchForm";
            this.Text = "HTTP Bench";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtBxNumberOfRequests;
        private System.Windows.Forms.Label lblTotalNumberOfRequests;
        private System.Windows.Forms.TextBox txtBxNumberOfTasks;
        private System.Windows.Forms.Label lblNumberOfTasks;
        private System.Windows.Forms.CheckBox chckBxWriteResponseToConsole;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RichTextBox rchTxtBxOutput;
        private System.Windows.Forms.ComboBox cmboBxUrls;
    }
}

