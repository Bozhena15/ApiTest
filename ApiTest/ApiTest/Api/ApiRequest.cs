using System;
using ApiTest.Utils;
using System.Net;

namespace ApiTest.Api
{
    public class ApiRequest
    {
        private PostsModel modelPostJson(string caseNum) => UtilsJson.ReadResultPostJsonFile(caseNum);
        private PostsModel modelPostApi(string caseNum, int num) => UtilsAPI.GetPostsModel(UtilsAPI.GetRequest(UtilsJson.GetRequest(caseNum)))[num];

        private UserModel modelUserApi(string caseNum, int num) => UtilsAPI.GetUserModel(UtilsAPI.GetRequest(UtilsJson.GetRequest(caseNum)))[num];

        public bool IsCorrectStatusCode(string caseNum, HttpStatusCode code) =>
            UtilsAPI.GetRequest(UtilsJson.GetRequest(caseNum)).StatusCode.Equals(code);

        public PostsModel GetAllPosts(string caseNum, HttpStatusCode code)
        {
            if (IsCorrectStatusCode(caseNum, code))
                return modelPostApi(caseNum, 0);

            return null;
        }

        public PostsModel GetPost99(string caseNum, HttpStatusCode code)
        {
            if (IsCorrectStatusCode(caseNum, code))
                return modelPostApi(caseNum, 0);
            return null;
        }

        public PostsModel CreateNewPost(string caseNum)
        {
            PostsModel model = modelPostJson(caseNum);
            model.Body = UtilsString.GetRandomString(Convert.ToInt32(UtilsJson.ReadJsonFile("stringLength")));
            model.Title = UtilsString.GetRandomString(Convert.ToInt32(UtilsJson.ReadJsonFile("stringLength")));

            UtilsAPI.PostRequest(model.ToString());

            return modelPostApi(caseNum, 100);
        }

        public UserModel GetAllUsers(string caseNum, HttpStatusCode code)
        {
            if (IsCorrectStatusCode(caseNum, code))
                return modelUserApi(caseNum, 4);

            return null;
        }

        public UserModel GetUser5(string caseNum, HttpStatusCode code)
        {
            if (IsCorrectStatusCode(caseNum, code))
                return modelUserApi(caseNum, 0);

            return null;
        }
    }
}

