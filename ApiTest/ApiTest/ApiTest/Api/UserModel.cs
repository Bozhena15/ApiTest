using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiTest.Api
{
    public class UserModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public List<AddressModel> Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string WebSite { get; set; }

        [JsonProperty("company")]
        public List<CompanyModel> Company { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            UserModel model = (UserModel)obj;

            return Name == model.Name && Id == model.Id &&
                   UserName == model.UserName && Email == model.Email
                   && Address[0] == model.Address[0] && Phone == model.Phone
                   && WebSite == model.WebSite && Company[0] == model.Company[0];
        }

        public override int GetHashCode() => Id.GetHashCode() + Name.GetHashCode() + UserName.GetHashCode() +
                                             Email.GetHashCode() + Address[0].GetHashCode() + Phone.GetHashCode()
                                             + WebSite.GetHashCode() + Company[0].GetHashCode();


        public override string ToString() => $"Id : {Id}\nName : {Name}\nUserName : {UserName}\n" +
                                             $"Email : {Email}\nAddress : {Address[0]}\nPhone : {Phone}\n" +
                                             $"WebSite : {WebSite}\nCompany : {Company[0]}";

    }
}
