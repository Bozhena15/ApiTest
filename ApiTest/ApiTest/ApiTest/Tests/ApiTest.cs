using NUnit.Framework;
using ApiTest.Api;
using System.Net;
using ApiTest.Utils;
using Aquality.Selenium.Browsers;

namespace ApiTest.Tests
{
    public class ApiTest : BaseTest
    {
        private PostsModel modelPostJson(string caseNum) => UtilsJson.ReadResultPostJsonFile(caseNum);
        private UserModel modelUserJson(string caseNum) => UtilsJson.ReadResultUserJsonFile(caseNum);

        [Test]
        public void TestAPI()
        {
            ApiRequest request = new ApiRequest();

            Assert.AreEqual(request.GetAllPosts("1", HttpStatusCode.OK).GetHashCode(), modelPostJson("1").GetHashCode());
            AqualityServices.Logger.Info("Get all posts");

            Assert.AreEqual(request.GetPost99("2", HttpStatusCode.OK).GetHashCode(), modelPostJson("2").GetHashCode());
            AqualityServices.Logger.Info("Get post 99");

            Assert.IsTrue(request.IsCorrectStatusCode("3", HttpStatusCode.NotFound), "Error with status");
            AqualityServices.Logger.Info("Status is not found");

            Assert.AreEqual(request.GetAllUsers("5", HttpStatusCode.OK).GetHashCode(), modelUserJson("5").GetHashCode());
            AqualityServices.Logger.Info("Get all users");

            Assert.AreEqual(request.GetUser5("6", HttpStatusCode.OK).GetHashCode(), modelUserJson("6").GetHashCode());
            AqualityServices.Logger.Info("Get user 5");
        }
    }
}
