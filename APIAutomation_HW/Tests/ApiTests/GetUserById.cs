using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using NUnit.Framework;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Category("API_Smoke")]
    public class GetUserById : BaseApiTests
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
            var userLookup = new UserLookup();
            var response = userLookup.GetUserById_NotFound();

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));

            userLookup.AssertGetResponse_GetUserById_NotFound("Could not find user with id: [2244994946].", "Not Found Error", "2244994946", response);
        }

        [Test, Description("Endpoint: 2/users/{:id}. Used: Authentication to Twitter")]
        public static void GET_UserById_200_DefaultPayload()
        {
            var userLookup = new UserLookup();
            var response = userLookup.GetUserById_DefaultPayload();
            

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));

            userLookup.AssertGetResponse_GetUserById_DefaultPayload("2244994945", "Twitter Dev", "TwitterDev", response);
        }



    }
}

