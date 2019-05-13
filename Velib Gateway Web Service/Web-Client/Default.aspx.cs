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

        public void Validate(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            cities = client.GetAllCities().ToList();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            client.SetTimer(ts);


            DropDownList1.DataSource = cities;
            DropDownList1.DataBind();
        }

        public void IndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            cityInfo = client.GetStationCity(value).ToList();

            DropDownList2.DataSource = cityInfo;
            DropDownList2.DataBind();
        }


    }
}