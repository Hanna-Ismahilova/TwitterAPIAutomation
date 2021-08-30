using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using NUnit.Framework;

namespace APIAutomation_HW.Tests.ApiTests
{
    public class GetUserById
    {
        [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("User_Lookup")]
        public class GetTweet : BaseApiTests

        {
            [SetUp]
            public void Setup()
            {
                SetBaseUriAndAuth();
                AuthTwitter();
            }

            [Test, Description("Endpoint: /users/{:id}. Used: Authentication to Twitter")]
            public static void GET_UserById_NotFound_Success()
            {

                UserLookup.GetUserById();

                Assert.That(Response.ErrorMessage, Is.Not.Empty);
                Assert.That(Response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Assert.That(Response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));



                UserLookup.AssertGetResponse("Could not find user with id: [2244994946].", "Not Found Error", "2244994946");
                //TweetLookup.GetResponseOfResource(Response.Content);
            }

        }
    }
}
