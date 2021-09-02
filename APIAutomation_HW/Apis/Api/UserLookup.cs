using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace APIAutomation_HW.Apis.Api
{
    public class UserLookup : BaseApiTests
    {
        readonly CommonMethods deserialize = new();

        public IRestResponse GetUserById_NotFound()
        {
            var request = new RestRequest("/2/users/2244994946", Method.GET);
            return GetResponse(request);
        }

        public IRestResponse GetUserById_DefaultPayload()
        {
            var request = new RestRequest("/2/users/2244994945", Method.GET);
            return GetResponse(request);
        }

        public IRestResponse GetUserByUsername_NotFound()
        {
            var request = new RestRequest("2/users/by/username/TwitterDec", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<List<GetUserByIdModel>>(request);
        }

        public void AssertGetResponse_GetUserById_NotFound(string detail, string title, string userIdValue, IRestResponse response)
        {            
            var output = deserialize.DeserialiseResponse<List<GetUserByIdModel>>(response);

            var userNotFoundDetail = output.First()?.Errors?.First()?.Detail;
            var userNotFoundTitle = output.First()?.Errors?.First()?.Title;
            var userNotFoundValue = output.First()?.Errors?.First()?.Value;

            Assert.That(userNotFoundDetail, Is.EqualTo(detail), "Detail text is not correct");
            Assert.That(userNotFoundTitle, Is.EqualTo(title), "Title is not correct");
            Assert.That(userNotFoundValue, Is.EqualTo(userIdValue), "User id value is not correct");
        }

        public void AssertGetResponse_GetUserById_DefaultPayload(string id, string name, string userName, IRestResponse response)
        {
            var output = deserialize.DeserialiseResponse<GetTweetModel>(response);

            var tweetId = output.Data?.Id; //null check "?". do that for each test
            var tweetUserName = output.Data?.Name;
            var tweetUserUsername = output.Data?.Username;

            Assert.That(tweetId, Is.EqualTo(id));
            Assert.That(tweetUserName, Is.EqualTo(name));
            Assert.That(tweetUserUsername, Is.EqualTo(userName));
        }

        public void AssertGetResponse_GetUserByUsername_NotFound(string detail, string title, string userIdValue, string resourceId, IRestResponse response)
        {
            var output = deserialize.DeserialiseResponse<List<GetUserByIdModel>>(response);

            var userNotFoundDetail = output.First()?.Errors?.First()?.Detail;
            var userNotFoundTitle = output.First()?.Errors?.First()?.Title;
            var userNotFoundValue = output.First()?.Errors?.First()?.Value;
            var userNotFoundResourceId = output.First()?.Errors?.First()?.Resource_id;

            Assert.That(userNotFoundDetail, Is.EqualTo(detail), "Detail text is not correct");
            Assert.That(userNotFoundTitle, Is.EqualTo(title), "Title is not correct");
            Assert.That(userNotFoundValue, Is.EqualTo(userIdValue), "User id value is not correct");
            Assert.That(userNotFoundResourceId, Is.EqualTo(resourceId), "Resource id is not correct");
        }

    }
}
