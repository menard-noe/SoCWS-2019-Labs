using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json.Linq;

namespace IntermediaryWS
{

    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class IntermediaryDecaux : IIntermediaryDecaux
    {
        //https://maps.googleapis.com/maps/api/directions/json?origin=Disneyland&destination=Universal+Studios+Hollywood&key=YOUR_API_KEY




        //String cities;
        Stat stat;
        String infos;
        List<Stations> stationList;
        IntermediaryDecaux()
        {
            stat = new Stat();
            stat.writeFile();
            
            String contract = "Lyon";
            stat.AddWSVelibRequest();
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?apiKey=0d3d77b4dfec90f83ec727cf828e8c94c599f2ef&contract=" + contract);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            infos = reader.ReadToEnd();

            stationList = ParseStations(infos);

        }


        public String GetStationsInfoCity(int value)
        {
            stat.AddClientRequestIWS();
            return infos;
        }

        public List<Double> FindStation(String depart, String arrive)
        {
            stat.AddClientRequestIWS();
            stat.AddClientRequestGoogle();

            List<Double> list = new List<Double>();

            stat.AddClientRequestGoogle();
            Tuple<double, double> departTuple = GetCoordonate("https://maps.googleapis.com/maps/api/geocode/json?address=" + depart + "&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4");

            list.AddRange(findClosestStation(departTuple));

            stat.AddClientRequestGoogle();
            Tuple<double, double> arrivalTuple = GetCoordonate("https://maps.googleapis.com/maps/api/geocode/json?address=" + arrive + "&key=AIzaSyCnEnbiMPFHqc_frV2vB8D9pFxnYcLVXO4");

            list.AddRange(findClosestStation(arrivalTuple));

            return list;
        }

        public Tuple<double, double> GetCoordonate(String name)
        {
            name = name.Replace(" ", "%20");
            WebRequest request = WebRequest.Create(name);
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

            Tuple<double, double> t = new Tuple<double, double>(lat, lng);

            return t;
        }

        public List<Double> findClosestStation(Tuple<double, double> t)
        {
            String name = "";
            double distance = 5000000;
            int i = 0;
            int count = 0;
            List<Double> list = new List<Double>();

            foreach (Stations station in stationList)
            {
                double x = (station.Lng - t.Item2) * Math.Cos((station.Lat + t.Item1) / 2);
                double y = (station.Lat - t.Item1);
                double z = Math.Sqrt((x * x + y * y));

                if (z < distance)
                {
                    distance = z;
                    name = station.Name + " " + station.Address;
                    count = i;
                    list.Clear();
                    list.Add(station.Lat);
                    list.Add(station.Lng);
                }
                i++;
            }

            return list;
        }

        List<Stations> ParseStations(String json)
        {
            List < Stations > stations = new List<Stations>();
            JArray jArray = JArray.Parse(json);

            for (int i = 0; i < jArray.Count(); i++)
            {
             
                JObject jObject = (JObject)jArray[i];
                String name = (String) jObject.GetValue("contract_name");
                String address = (String) jObject.GetValue("address");

                JObject position = (JObject)jObject.GetValue("position");
                Double lat = (Double)position.GetValue("lat");
                Double lng = (Double)position.GetValue("lng");

                int bikes = (int)jObject.GetValue("available_bikes");


                Stations station = new Stations(name, address, lat, lng, bikes);

                stations.Add(station);
            }

            return stations;
        }
    }
}
