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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateForm(object sender, EventArgs e)
        {
            IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            TextBox1.Text = client.GetCities(14);

            String depart = Depart.Text;
            String arrive = Arrive.Text;


            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=18RoutedeRouen,Darn%C3%A9tal&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            //TextBox1.Text = responseFromServer;

            //string json = JsonConvert.SerializeObject(responseFromServer);

            JObject jObject = JObject.Parse(responseFromServer);
            JArray jArray = (JArray)jObject.GetValue("results");
            jObject = (JObject)jArray[0];
            jObject = (JObject)jObject.GetValue("geometry");
            jObject = (JObject)jObject.GetValue("location");
            double lat = (double)jObject.GetValue("lat");
            double lng = (double)jObject.GetValue("lng");

            TextBox1.Text = lat.ToString();

            //json.JsonConvert.DeserializeObject<json>(json);





            //https://maps.googleapis.com/maps/api/directions/json?origin=Disneyland&destination=Universal+Studios+Hollywood&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4


        }
    }
}