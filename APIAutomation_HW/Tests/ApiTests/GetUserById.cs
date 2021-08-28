using APIAutomation_HW.Apis;
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

                TweetLookup.GetSingleTweet();

                Assert.That(Response.ErrorMessage, Is.Not.Empty);
                Assert.That(Response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Assert.That(Response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));
                Assert.That(Response.Content.Contains("\"id\":\"1431598792743301128\""));
                Assert.That(Response.Content.Contains("\"text\":\"Test\""));


                //TweetLookup.AssertGetResponse("1431598792743301128", "Test");
                //TweetLookup.GetResponseOfResource(Response.Content);
            }

        }
    }
}
