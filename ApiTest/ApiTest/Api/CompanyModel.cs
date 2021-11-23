using System;
using Newtonsoft.Json;

namespace ApiTest.Api
{
    public class CompanyModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            CompanyModel model = (CompanyModel)obj;

            return Name == model.Name && CatchPhrase == model.CatchPhrase &&
                   Bs == model.Bs;
        }

        public override int GetHashCode() => Name.GetHashCode() + CatchPhrase.GetHashCode() + Bs.GetHashCode();

        public override string ToString() => $"Name : {Name}\nCatchPhrase : {CatchPhrase}\nBs : {Bs}";
    }
}
