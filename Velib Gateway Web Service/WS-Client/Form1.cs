using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS_Client.IntermediaryDecauxClient;

namespace WS_Client
{
    public partial class Form1 : Form
    {
        Stat stat;
        public Form1()
        {
            InitializeComponent();
            this.Init();
        }

        public void Init()
        {
            AdminClient client = new AdminClient();


            //TimeSpan ts = stopWatch.Elapsed;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            stat = client.GetStat();
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;
            client.SetTimer(ts2);

            textBox1.Text = stat.ClientRequestGoogle1.ToString();


            textBox2.Text = stat.WSVelibRequest1.ToString();

            if (stat.CounterAverageDelayIWS != 0)
            {
                TimeSpan ts = new TimeSpan(stat.AverageDelayIWS1.Ticks / stat.CounterAverageDelayIWS);

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

                textBox3.Text = elapsedTime;
            }
            else
            {
                textBox3.Text = "None";
            }

            textBox4.Text = stat.ClientRequestIWS1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Init();
        }
    }
}
