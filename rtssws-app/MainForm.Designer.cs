namespace rtss_srv
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtssStatusNameLabel = new System.Windows.Forms.Label();
            this.rtssStatusValueLabel = new System.Windows.Forms.Label();
            this.RtssGroup = new System.Windows.Forms.GroupBox();
            this.refreshRTSSStatus = new System.Windows.Forms.Button();
            this.runRtssButton = new System.Windows.Forms.Button();
            this.srvGroup = new System.Windows.Forms.GroupBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.LinkLabel = new System.Windows.Forms.LinkLabel();
            this.srvStartStopButton = new System.Windows.Forms.Button();
            this.srvStatusValueLabel = new System.Windows.Forms.Label();
            this.srvStatusNameLabel = new System.Windows.Forms.Label();
            this.SrvPortNum = new System.Windows.Forms.NumericUpDown();
            this.srvPortNameLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PerfStatusValueLabel = new System.Windows.Forms.Label();
            this.PerfStatusNameLabel = new System.Windows.Forms.Label();
            this.PollRateLabel = new System.Windows.Forms.Label();
            this.PollRateCombo = new System.Windows.Forms.ComboBox();
            this.RtssGroup.SuspendLayout();
            this.srvGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SrvPortNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtssStatusNameLabel
            // 
            this.rtssStatusNameLabel.AutoSize = true;
            this.rtssStatusNameLabel.Location = new System.Drawing.Point(6, 24);
            this.rtssStatusNameLabel.Name = "rtssStatusNameLabel";
            this.rtssStatusNameLabel.Size = new System.Drawing.Size(40, 13);
            this.rtssStatusNameLabel.TabIndex = 0;
            this.rtssStatusNameLabel.Text = "Status:";
            // 
            // rtssStatusValueLabel
            // 
            this.rtssStatusValueLabel.AutoSize = true;
            this.rtssStatusValueLabel.Location = new System.Drawing.Point(52, 24);
            this.rtssStatusValueLabel.Name = "rtssStatusValueLabel";
            this.rtssStatusValueLabel.Size = new System.Drawing.Size(0, 13);
            this.rtssStatusValueLabel.TabIndex = 1;
            // 
            // RtssGroup
            // 
            this.RtssGroup.Controls.Add(this.refreshRTSSStatus);
            this.RtssGroup.Controls.Add(this.runRtssButton);
            this.RtssGroup.Controls.Add(this.rtssStatusNameLabel);
            this.RtssGroup.Controls.Add(this.rtssStatusValueLabel);
            this.RtssGroup.Location = new System.Drawing.Point(12, 123);
            this.RtssGroup.Name = "RtssGroup";
            this.RtssGroup.Size = new System.Drawing.Size(276, 76);
            this.RtssGroup.TabIndex = 2;
            this.RtssGroup.TabStop = false;
            this.RtssGroup.Text = "Riva Tuner Statistics Server (RTSS)";
            // 
            // refreshRTSSStatus
            // 
            this.refreshRTSSStatus.Location = new System.Drawing.Point(9, 40);
            this.refreshRTSSStatus.Name = "refreshRTSSStatus";
            this.refreshRTSSStatus.Size = new System.Drawing.Size(75, 24);
            this.refreshRTSSStatus.TabIndex = 3;
            this.refreshRTSSStatus.Text = "Refresh";
            this.refreshRTSSStatus.UseVisualStyleBackColor = true;
            this.refreshRTSSStatus.Click += new System.EventHandler(this.RefreshRTSSStatus_Click);
            // 
            // runRtssButton
            // 
            this.runRtssButton.Location = new System.Drawing.Point(196, 41);
            this.runRtssButton.Name = "runRtssButton";
            this.runRtssButton.Size = new System.Drawing.Size(75, 23);
            this.runRtssButton.TabIndex = 2;
            this.runRtssButton.Text = "Run";
            this.runRtssButton.UseVisualStyleBackColor = true;
            this.runRtssButton.Visible = false;
            this.runRtssButton.Click += new System.EventHandler(this.RunRtssButton_Click);
            // 
            // srvGroup
            // 
            this.srvGroup.Controls.Add(this.PortLabel);
            this.srvGroup.Controls.Add(this.LinkLabel);
            this.srvGroup.Controls.Add(this.srvStartStopButton);
            this.srvGroup.Controls.Add(this.srvStatusValueLabel);
            this.srvGroup.Controls.Add(this.srvStatusNameLabel);
            this.srvGroup.Controls.Add(this.SrvPortNum);
            this.srvGroup.Controls.Add(this.srvPortNameLabel);
            this.srvGroup.Location = new System.Drawing.Point(12, 12);
            this.srvGroup.Name = "srvGroup";
            this.srvGroup.Size = new System.Drawing.Size(276, 105);
            this.srvGroup.TabIndex = 3;
            this.srvGroup.TabStop = false;
            this.srvGroup.Text = "Web server";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(6, 50);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(29, 13);
            this.PortLabel.TabIndex = 7;
            this.PortLabel.Text = "Port:";
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Location = new System.Drawing.Point(44, 72);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(49, 13);
            this.LinkLabel.TabIndex = 6;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.Text = "linkLabel";
            this.LinkLabel.Visible = false;
            this.LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // srvStartStopButton
            // 
            this.srvStartStopButton.Location = new System.Drawing.Point(195, 19);
            this.srvStartStopButton.Name = "srvStartStopButton";
            this.srvStartStopButton.Size = new System.Drawing.Size(75, 23);
            this.srvStartStopButton.TabIndex = 4;
            this.srvStartStopButton.UseVisualStyleBackColor = true;
            this.srvStartStopButton.Visible = false;
            this.srvStartStopButton.Click += new System.EventHandler(this.SrvStartStopButton_Click);
            // 
            // srvStatusValueLabel
            // 
            this.srvStatusValueLabel.AutoSize = true;
            this.srvStatusValueLabel.Location = new System.Drawing.Point(52, 25);
            this.srvStatusValueLabel.Name = "srvStatusValueLabel";
            this.srvStatusValueLabel.Size = new System.Drawing.Size(0, 13);
            this.srvStatusValueLabel.TabIndex = 3;
            // 
            // srvStatusNameLabel
            // 
            this.srvStatusNameLabel.AutoSize = true;
            this.srvStatusNameLabel.Location = new System.Drawing.Point(6, 25);
            this.srvStatusNameLabel.Name = "srvStatusNameLabel";
            this.srvStatusNameLabel.Size = new System.Drawing.Size(40, 13);
            this.srvStatusNameLabel.TabIndex = 2;
            this.srvStatusNameLabel.Text = "Status:";
            // 
            // SrvPortNum
            // 
            this.SrvPortNum.Location = new System.Drawing.Point(195, 50);
            this.SrvPortNum.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.SrvPortNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SrvPortNum.Name = "SrvPortNum";
            this.SrvPortNum.Size = new System.Drawing.Size(75, 20);
            this.SrvPortNum.TabIndex = 1;
            this.SrvPortNum.Value = new decimal(new int[] {
            8089,
            0,
            0,
            0});
            // 
            // srvPortNameLabel
            // 
            this.srvPortNameLabel.AutoSize = true;
            this.srvPortNameLabel.Location = new System.Drawing.Point(6, 72);
            this.srvPortNameLabel.Name = "srvPortNameLabel";
            this.srvPortNameLabel.Size = new System.Drawing.Size(32, 13);
            this.srvPortNameLabel.TabIndex = 0;
            this.srvPortNameLabel.Text = "Host:";
            // 
            // minimizeButton
            // 
            this.minimizeButton.Location = new System.Drawing.Point(12, 289);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(75, 23);
            this.minimizeButton.TabIndex = 4;
            this.minimizeButton.Text = "Minimize";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(217, 289);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "RTSS Web Server";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "RTSS Web Server";
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PollRateCombo);
            this.groupBox1.Controls.Add(this.PollRateLabel);
            this.groupBox1.Controls.Add(this.PerfStatusValueLabel);
            this.groupBox1.Controls.Add(this.PerfStatusNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performance monitor";
            // 
            // PerfStatusValueLabel
            // 
            this.PerfStatusValueLabel.AutoSize = true;
            this.PerfStatusValueLabel.Location = new System.Drawing.Point(60, 23);
            this.PerfStatusValueLabel.Name = "PerfStatusValueLabel";
            this.PerfStatusValueLabel.Size = new System.Drawing.Size(0, 13);
            this.PerfStatusValueLabel.TabIndex = 2;
            // 
            // PerfStatusNameLabel
            // 
            this.PerfStatusNameLabel.AutoSize = true;
            this.PerfStatusNameLabel.Location = new System.Drawing.Point(14, 23);
            this.PerfStatusNameLabel.Name = "PerfStatusNameLabel";
            this.PerfStatusNameLabel.Size = new System.Drawing.Size(40, 13);
            this.PerfStatusNameLabel.TabIndex = 1;
            this.PerfStatusNameLabel.Text = "Status:";
            // 
            // PollRateLabel
            // 
            this.PollRateLabel.AutoSize = true;
            this.PollRateLabel.Location = new System.Drawing.Point(14, 46);
            this.PollRateLabel.Name = "PollRateLabel";
            this.PollRateLabel.Size = new System.Drawing.Size(70, 13);
            this.PollRateLabel.TabIndex = 3;
            this.PollRateLabel.Text = "Poll rate (ms):";
            // 
            // PollRateCombo
            // 
            this.PollRateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PollRateCombo.FormattingEnabled = true;
            this.PollRateCombo.Location = new System.Drawing.Point(195, 43);
            this.PollRateCombo.Name = "PollRateCombo";
            this.PollRateCombo.Size = new System.Drawing.Size(75, 21);
            this.PollRateCombo.TabIndex = 4;
            this.PollRateCombo.SelectedIndexChanged += new System.EventHandler(this.PollRateCombo_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.srvGroup);
            this.Controls.Add(this.RtssGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RTSS Web Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.RtssGroup.ResumeLayout(false);
            this.RtssGroup.PerformLayout();
            this.srvGroup.ResumeLayout(false);
            this.srvGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SrvPortNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label rtssStatusNameLabel;
        private System.Windows.Forms.Label rtssStatusValueLabel;
        private System.Windows.Forms.GroupBox RtssGroup;
        private System.Windows.Forms.Button runRtssButton;
        private System.Windows.Forms.Button refreshRTSSStatus;
        private System.Windows.Forms.GroupBox srvGroup;
        private System.Windows.Forms.Button srvStartStopButton;
        private System.Windows.Forms.Label srvStatusValueLabel;
        private System.Windows.Forms.Label srvStatusNameLabel;
        private System.Windows.Forms.NumericUpDown SrvPortNum;
        private System.Windows.Forms.Label srvPortNameLabel;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel LinkLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PerfStatusValueLabel;
        private System.Windows.Forms.Label PerfStatusNameLabel;
        private System.Windows.Forms.ComboBox PollRateCombo;
        private System.Windows.Forms.Label PollRateLabel;
    }
}

