using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApiTest.Api;
namespace ApiTest.Utils
{
    public static class UtilsJson
    {
        private static string pathJson = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../")) + "Resources/dataTest.json";
        public static string ReadJsonFile(string key)
        {
            try
            {
                dynamic file = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
                return Convert.ToString(file[$"{key}"]);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static PostsModel ReadResultPostJsonFile(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            PostsModel model = new PostsModel();

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                {
                    model.UserId = file["result"].First["userId"];
                    model.Id = file["result"].First["id"];
                    model.Title = file["result"].First["title"];
                    model.Body = file["result"].First["body"];
                    break;
                }
            }

            return model;
        }

        public static UserModel ReadResultUserJsonFile(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            UserModel model = new UserModel();

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                {
                    model.Id = file["result"].First["id"];
                    model.Name = file["result"].First["name"];
                    model.UserName = file["result"].First["username"];
                    model.Email = file["result"].First["email"];

                    model.Address = new List<AddressModel>();
                    model.Address.Add(ReadResultAddressJsonFile(caseNum));

                    model.Phone = file["result"].First["phone"];
                    model.WebSite = file["result"].First["website"];

                    model.Company = new List<CompanyModel>();
                    model.Company.Add(ReadResultCompanyJsonFile(caseNum));
                    break;
                }
            }

            return model;
        }

        private static AddressModel ReadResultAddressJsonFile(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            AddressModel model = new AddressModel();

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                {
                    foreach (var item in file.result)
                    {
                        model.Street = item["address"]["street"];
                        model.Suite = item["address"]["suite"];
                        model.City = item["address"]["city"];
                        model.Zipcode = item["address"]["zipcode"];

                        model.Geo = new List<GeoModel>();
                        model.Geo.Add(ReadResultGeoJsonFile(caseNum));
                    }
                    break;
                }
            }

            return model;
        }

        private static GeoModel ReadResultGeoJsonFile(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            GeoModel model = new GeoModel();

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                {
                    foreach (var item in file.result)
                    {
                        model.Lat = item["address"]["geo"]["lat"];
                        model.Lng = item["address"]["geo"]["lng"];
                    }
                    break;
                }
            }

            return model;
        }

        private static CompanyModel ReadResultCompanyJsonFile(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            CompanyModel model = new CompanyModel();

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                {
                    foreach (var item in file.result)
                    {
                        model.Name = item["company"]["name"];
                        model.CatchPhrase = item["company"]["catchPhrase"];
                        model.Bs = item["company"]["bs"];
                    }
                    break;
                }
            }

            return model;
        }

        public static string GetRequest(string caseNum)
        {
            dynamic result = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));

            foreach (var file in result.data)
            {
                if (Convert.ToString(file.caseNum) == caseNum)
                    return Convert.ToString(file.request);
            }

            return string.Empty;
        }
    }
}

