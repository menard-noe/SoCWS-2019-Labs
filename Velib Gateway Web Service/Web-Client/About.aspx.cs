using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Client.IntermediaryDecaux;

namespace Web_Client
{
    public partial class About : Page
    {
        public String originAddress = "Rouen";
        public String destinationAddress = "Strasbourg";
        public String lat1 = "45.808425";
        public String lng1 = "4.898393";
        public String lat2 = "45.808425";
        public String lng2 = "4.898393";


        protected void Page_Load(object sender, EventArgs e)
        {
            originAddress = Request.QueryString["originAddress"];
            destinationAddress = Request.QueryString["destinationAddress"];
            lat1 = Request.QueryString["lat1"];
            lng1 = Request.QueryString["lng1"];
            lat2 = Request.QueryString["lat2"];
            lng2 = Request.QueryString["lng2"];
        }

        protected void ValidateForm(object sender, EventArgs e)
        {
            IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            //TextBox1.Text = client.GetCities(14);

            String depart = Depart.Text;
            String arrive = Arrive.Text;

            double[] stationsList = new double[4];
            //string[] stationsList = new string[2];
            stationsList = client.FindStation(depart, arrive);



            /*WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=18RoutedeRouen,Darn%C3%A9tal&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();


            JObject jObject = JObject.Parse(responseFromServer);
            JArray jArray = (JArray)jObject.GetValue("results");
            jObject = (JObject)jArray[0];
            jObject = (JObject)jObject.GetValue("geometry");
            jObject = (JObject)jObject.GetValue("location");
            double lat = (double)jObject.GetValue("lat");
            double lng = (double)jObject.GetValue("lng");

            TextBox1.Text = lat.ToString();*/


            string url3 = "About?" +
            "originAddress=" + HttpUtility.UrlEncode(depart) +
            "&destinationAddress=" + HttpUtility.UrlEncode(arrive) +
            "&lat1=" + HttpUtility.UrlEncode(stationsList[0].ToString()) +
            "&lng1=" + HttpUtility.UrlEncode(stationsList[1].ToString()) +
            "&lat2=" + HttpUtility.UrlEncode(stationsList[2].ToString()) +
            "&lng2=" + HttpUtility.UrlEncode(stationsList[3].ToString());
            Response.Redirect(url3);



            //https://maps.googleapis.com/maps/api/directions/json?origin=Disneyland&destination=Universal+Studios+Hollywood&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4


        }
    }
}