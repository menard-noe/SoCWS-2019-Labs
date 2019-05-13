using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Client.IntermediaryDecaux;

namespace Web_Client
{
    public partial class _Default : Page
    {
        List<String> cities;
        List<Stations> cityInfo;
        IntermediaryDecauxClient client;

        protected void Page_Load(object sender, EventArgs e)
        {
            client = new IntermediaryDecauxClient();
        }

        protected void Validate(object sender, EventArgs e) { 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cities = client.GetAllCities().ToList();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            client.SetTimer(ts);

            cities = cities.ConvertAll(d => d.ToUpper());

            ListBox1.DataSource = cities;
            ListBox1.DataBind();
            ListBox1.Visible = true;
            Button1.Visible = false;
        }

        public void IndexChanged(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            string value = (string)list.SelectedValue;
            cityInfo = client.GetStationCity(value.ToLower()).ToList();

            ListBox2.DataSource = cityInfo;
            ListBox2.DataBind();
            ListBox2.Visible = true;
        }


    }
}