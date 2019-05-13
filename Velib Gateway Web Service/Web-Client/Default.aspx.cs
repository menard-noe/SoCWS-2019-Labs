﻿using System;
using System.Collections.Generic;
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
            cities = client.GetAllCities().ToList();
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