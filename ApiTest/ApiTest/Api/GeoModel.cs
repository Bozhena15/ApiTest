using System;
using Newtonsoft.Json;
namespace ApiTest.Api
{
    public class GeoModel
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            GeoModel model = (GeoModel)obj;

            return Lat == model.Lat && Lng == model.Lng;
        }

        public override int GetHashCode() => Lat.GetHashCode() + Lng.GetHashCode();

        public override string ToString() => $"Lat : {Lat}\nLng : {Lng}";   
    }
}
