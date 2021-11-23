using System;
using RestSharp;
using Aquality.Selenium.Browsers;
using ApiTest.Api;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
namespace ApiTest.Utils
{
    public static class UtilsAPI
    {
        private static RestClient client = new RestClient(AqualityServices.Browser.CurrentUrl);
        private static RestRequest request(string getRequest, Method method) => new RestRequest(getRequest, method);
        private static RestRequest request(Method method) => new RestRequest(method);

        public static IRestResponse GetRequest(string getRequest) =>
            client.Execute(request(getRequest, Method.GET));

        public static IRestResponse PostRequest(string body)
        {
            request(Method.POST).RequestFormat = DataFormat.Json;
            request(Method.POST).AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            return client.Execute(request(Method.POST));
        }

        public static List<PostsModel> GetPostsModel(IRestResponse response) =>
            new JsonDeserializer().Deserialize<List<PostsModel>>(response);

        public static List<UserModel> GetUserModel(IRestResponse response) =>
            new JsonDeserializer().Deserialize<List<UserModel>>(response);
    }
}

