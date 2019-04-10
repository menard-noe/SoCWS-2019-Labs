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
        String cities;
        String infos;
        IntermediaryDecaux()
        {
            String contract = "Lyon";
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?apiKey=0d3d77b4dfec90f83ec727cf828e8c94c599f2ef&contract=" + contract);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            infos = reader.ReadToEnd();
            //infos = JArray.Parse(responseFromServer);


            request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=0d3d77b4dfec90f83ec727cf828e8c94c599f2ef");
            response = request.GetResponse();
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);
            cities = reader.ReadToEnd();
        }

        public String GetCities(int value)
        {
            return cities;
        }

        public String GetStationsInfoCity(int value)
        {
            return infos;
            //return string.Format("You entered: {0}", value);
        }
    }
}
