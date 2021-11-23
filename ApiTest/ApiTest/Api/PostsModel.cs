using System;
using Newtonsoft.Json;

namespace ApiTest.Api
{
    public class PostsModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            PostsModel model = (PostsModel)obj;

            return UserId == model.UserId && Id == model.Id &&
                   Title == model.Title && Body == model.Body;
        }

        public override int GetHashCode() => Id.GetHashCode() + UserId.GetHashCode();

        public override string ToString() => $"\"userId\" : \"{UserId}\",\n" +
                                             $"\"id\" : \"{Id}\",\n" +
                                             $"\"title\" : \"{Title}\",\n" +
                                             $"\"body\" : \"{Body}\",\n";
    }
}

