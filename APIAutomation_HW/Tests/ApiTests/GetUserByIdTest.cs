using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using NUnit.Framework;
using System.Net;
using RestSharp;
using APIAutomation_HW.Utils.CommonMethods;
using APIAutomation_HW.Apis.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Category("API_Smoke")]
    public class GetUserByIdTest : BaseApi
    {
        [Category("User_Lookup")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Description("Endpoint: 2/users/{:id}. Used: Authentication to Twitter")]
        public static void GET_UserById_200_NotFound()
        {
            var userLookup = new UserLookupApi();
            var deserialize = new CommonMethods();

            var response = userLookup.GetUserById_NotFound();

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(ResponseStatus.Completed));

            var output = deserialize.DeserialiseResponse<List<GetUserByIdModel>>(response);

            Assert.AreEqual(output.First().Errors.First().Detail, "Could not find user with id: [2244994946].");
            Assert.AreEqual(output.First().Errors.First().Title, "Not Found Error");
            Assert.AreEqual(output.First().Errors.First().Value, "2244994946");
        }

        [Test, Description("Endpoint: 2/users/{:id}. Used: Authentication to Twitter")]
        public static void GET_UserById_200_DefaultPayload()
        {
            var userLookup = new UserLookupApi();
            var deserialize = new CommonMethods();

            var response = userLookup.GetUserById_DefaultPayload();
   
            var output = deserialize.DeserialiseResponse<GetTweetModel>(response);

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(ResponseStatus.Completed));

            Assert.AreEqual(output.Data.Id, 2244994945);
            Assert.AreEqual(output.Data.Name, "Twitter Dev");
            Assert.AreEqual(output.Data.Username, "TwitterDev");
        }
    }
}

