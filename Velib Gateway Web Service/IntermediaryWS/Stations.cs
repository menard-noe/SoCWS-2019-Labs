using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediaryWS
{
    class Stations
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

        public double Lat { get => lat; set => lat = value; }
        public double Lng { get => lng; set => lng = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int Bikes { get => bikes; set => bikes = value; }
    }
}
