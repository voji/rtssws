using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using rtss_srv.DataProvider;

namespace rtss_srv
{
    public partial class MainForm : Form
    {
        private int portNum;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            UpdateRtssState();
            PollRateCombo.Items.Add(1000);
            PollRateCombo.Items.Add(500);
            PollRateCombo.Items.Add(200);
            PollRateCombo.Items.Add(100);
            PollRateCombo.Items.Add(50);
            PollRateCombo.Items.Add(20);
            PollRateCombo.Items.Add(10);
            PollRateCombo.Items.Add(5);
            PollRateCombo.Items.Add(1);
            string pollRate = ConfigurationManager.AppSettings["PollRate"];            
            PollRateCombo.SelectedIndex = int.Parse(pollRate);

            string port = ConfigurationManager.AppSettings["Port"];            
            SrvPortNum.Value = int.Parse(port);            
            bool result = NetworkHandler.StartService((uint)SrvPortNum.Value);
            HandleNetworkServiceStatus(result);
            srvStartStopButton.Visible = true;
        }

        private void UpdateRtssState()
        {
            RTSSDataProvider.RtssState rtssState = RTSSDataProvider.GetRtssState();
            switch (rtssState)
            {
                case RTSSDataProvider.RtssState.RUNNING:
                    rtssStatusValueLabel.Text = "Running";
                    rtssStatusValueLabel.ForeColor = Color.Green;
                    runRtssButton.Visible = false;
                    break;
                case RTSSDataProvider.RtssState.RUNABLE:
                    rtssStatusValueLabel.Text = "Runnable";
                    rtssStatusValueLabel.ForeColor = Color.Orange;
                    runRtssButton.Visible = true;
                    break;
                case RTSSDataProvider.RtssState.NOT_FOUND:
                    rtssStatusValueLabel.Text = "Not found";
                    rtssStatusValueLabel.ForeColor = Color.Red;                    
                    break;
            }
        }
       

        private void RefreshRTSSStatus_Click(object sender, EventArgs e)
        {
            UpdateRtssState();
        }

        private void RunRtssButton_Click(object sender, EventArgs e)
        {
            runRtssButton.Visible = false;
            refreshRTSSStatus.Enabled = false;
            RTSSDataProvider.StartRtss();            
            UpdateRtssState();            
            refreshRTSSStatus.Enabled = true;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        private void HandleNetworkServiceStatus(bool status)
        {
            if (status)
            {
                srvStatusValueLabel.Text = "Running";
                srvStatusValueLabel.ForeColor = Color.Green;
                srvStartStopButton.Text = "Stop";
                LinkLabel.Text = "http://" + NetworkHandler.GetAddress()+ ":" + SrvPortNum.Value + "/start";
                LinkLabel.Visible = true;
                SrvPortNum.Enabled = false;
            }
            else
            {
                srvStatusValueLabel.Text = "Stopped";
                srvStatusValueLabel.ForeColor = Color.Red;
                srvStartStopButton.Text = "Start";
                LinkLabel.Visible = false;
                SrvPortNum.Enabled = true;
            }
        }

        private void SrvStartStopButton_Click(object sender, EventArgs e)
        {
            bool status;
            if (srvStartStopButton.Text == "Start")
            {
                if (portNum!= SrvPortNum.Value) {
                    portNum = (int)SrvPortNum.Value;
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);                
                    configFile.AppSettings.Settings["Port"].Value = SrvPortNum.Value.ToString();
                    configFile.Save(ConfigurationSaveMode.Modified);
                }
                status = NetworkHandler.StartService((uint)SrvPortNum.Value);
            } else
            {
                status = NetworkHandler.StopService();
            }
            HandleNetworkServiceStatus(status);
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LinkLabel.Text);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        /**
         * Gather data for every sec
         */
        private void Timer_Tick(object sender, EventArgs e)
        {
            PerfDataCache.TickResult result = PerfDataCache.Get().Tick(timer.Interval);
            switch (result)
            {
                case PerfDataCache.TickResult.IDLE:
                    PerfStatusValueLabel.Text = "Idle";
                    PerfStatusValueLabel.ForeColor = Color.Black;
                    break;
                case PerfDataCache.TickResult.RUN_W_RTSS:
                    PerfStatusValueLabel.Text = "Active (with fps)";
                    PerfStatusValueLabel.ForeColor = Color.Green;
                    break;
                case PerfDataCache.TickResult.RUN_WO_RTSS:
                    PerfStatusValueLabel.Text = "Active";
                    PerfStatusValueLabel.ForeColor = Color.Green;
                    break;
                default:
                    throw new Exception("Unknown result: " + result);
            }
        }

        private void PollRateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int origVal = timer.Interval;
            int newVal = (int)PollRateCombo.SelectedItem;
            if (origVal != newVal) { 
                timer.Interval = newVal;
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["PollRate"].Value = ""+PollRateCombo.SelectedIndex;
                configFile.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
