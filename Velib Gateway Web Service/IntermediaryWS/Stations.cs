using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    [DataContract]
    public class Stations
    {
        double lat;
        double lng;
        String name;
        String address;
        int bikes;

        public Stations(String name, String address, double lat, double lng, int bikes)
        {
            this.name = name;
            this.address = address;
            this.lat = lat;
            this.lng = lng;
            this.bikes = bikes;
        }
        [DataMember]
        public double Lat { get => lat; set => lat = value; }
        [DataMember]
        public double Lng { get => lng; set => lng = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Address { get => address; set => address = value; }
        [DataMember]
        public int Bikes { get => bikes; set => bikes = value; }
    }
}
