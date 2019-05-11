using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS_Client.IntermediaryDecaux;

namespace WS_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            richTextBox1.Text = 
            client.GetStationsInfoCity(14);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            /*richTextBox1.Text =
            client.GetCities(14);*/
        }
    }
}
