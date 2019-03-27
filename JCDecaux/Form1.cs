using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TD3WinFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            requestStation(comboBox1.SelectedItem.ToString(), textBox1.Text);
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            requestStation(comboBox1.SelectedItem.ToString(), textBox1.Text);
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                requestContract(textBox1.Text);
            }
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            requestContract(textBox1.Text);
        }

        public void requestContract(string contract)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?apiKey=0d3d77b4dfec90f83ec727cf828e8c94c599f2ef&contract=" + contract);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            string responseFromServer = reader.ReadToEnd();
            JArray array = JArray.Parse(responseFromServer);
            comboBox1.Items.Clear();
            foreach(JObject station in array)
            {
                comboBox1.Items.Add(station["name"].ToString());
            }
            comboBox1.SelectedItem = comboBox1.Items[0];
            //JObject json = (JObject)array[0];
            //textBox3.Text = json["number"].ToString();
            //textBox3.Text += responseFromServer;
        }

        public void requestStation(string station, string contract)
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/"+ station.Split(' ')[0] +"?apiKey=0d3d77b4dfec90f83ec727cf828e8c94c599f2ef&contract=" + contract);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            string responseFromServer = reader.ReadToEnd();
            //JArray array = JArray.Parse(responseFromServer);
            JObject json = JObject.Parse(responseFromServer);
            //textBox3.Text = json["number"].ToString();

            textBox3.Text = json["name"] + " (" + json["status"] + ")";
            textBox3.Text += Environment.NewLine + json["address"].ToString().ToLower();
            textBox3.Text += Environment.NewLine + "Available bikes : " + json["available_bikes"];
            textBox3.Text += Environment.NewLine + "Available bike stands : " + json["available_bike_stands"] + " / " + json["bike_stands"];
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
