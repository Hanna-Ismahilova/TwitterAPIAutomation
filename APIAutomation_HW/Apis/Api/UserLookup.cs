using APIAutomation_HW.Apis.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace APIAutomation_HW.Apis.Api
{
    public class UserLookup : BaseApiTests
    {
        public static void GetUserById()
        {
            Request = new RestRequest("/2/users/2244994946", Method.GET);
            GetResponse();
        }

        private static void GetResponse()
        {

            Response = Client.Execute<List<GetUserByIdModel>>(Request);

        }

        private static T DeserialiseResponse<T>()
        {
            JsonDeserializer deserialize = new();
            return deserialize.Deserialize<T>(Response);

        }


        public static void AssertGetResponse(string detail, string title, string userIdValue)
        {
            var output = DeserialiseResponse<List<GetUserByIdModel>>();

            var userNotFoundDetail = output.First()?.Errors?.First()?.Detail;         
            var userNotFoundTitle = output.First()?.Errors?.First()?.Title;
            var userNotFoundValue = output.First()?.Errors?.First()?.Value;

            Assert.That(userNotFoundDetail, Is.EqualTo(detail), "Detail text is not correct");
            Assert.That(userNotFoundTitle, Is.EqualTo(title), "Title is not correct");
            Assert.That(userNotFoundValue, Is.EqualTo(userIdValue), "User id value is not correct");


            //var output = deserialize.Deserialize<Dictionary<string, GetUserByIdModel>>(Response);


            //var userNotFoundDetail = output["detail"].Errors;
            //var userNotFoundTitle = output["title"].Errors;

            //Assert.That(userNotFoundDetail, Is.EqualTo("Could not find user with id: [2244994946]."), "Detail text is not correct");
            //Assert.That(userNotFoundTitle, Is.EqualTo("Not Found Error"), "Title is not correct");
        }

    }
}
