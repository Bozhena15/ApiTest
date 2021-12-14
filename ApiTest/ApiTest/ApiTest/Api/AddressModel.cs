using System;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace ApiTest.Api
{
    public class AddressModel
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public List<GeoModel> Geo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AddressModel model = (AddressModel)obj;

            return Street == model.Street && Suite == model.Suite &&
                   City == model.City && Zipcode == model.Zipcode &&
                   Geo[0] == model.Geo[0];
        }

        public override int GetHashCode() => Street.GetHashCode() + Suite.GetHashCode() + City.GetHashCode();

        public override string ToString() => $"Street : {Street}\nSuite : {Suite}\nCity : {City}\nZipcode : {Zipcode}\nGeo : {Geo[0]}";

    }
}

