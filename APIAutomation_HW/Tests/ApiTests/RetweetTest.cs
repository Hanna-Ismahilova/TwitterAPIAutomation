using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("API_Smoke")]
    public class RetweetTest : BaseApiTests
    {
        [Category("Tweet")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Order(1), Description("Endpoint: 1.1/statuses/retweet/:id.json, 1.1/statuses/unretweet/:id.json. Used: Authentication to Twitter")]
        public void POST_Retweet_UnRetweet_SingleTweet()
        {
            var deserialize = new CommonMethods();
            var retweet = new RetweetApi();

            var retweetResponse = retweet.PostReTweet();
            var retweetResult = deserialize.DeserialiseResponse<PostRetweetModel>(retweetResponse);

            Assert.That(retweetResponse.Content, Is.Not.Empty);
            Assert.That(retweetResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(retweetResponse.ResponseStatus.Equals(ResponseStatus.Completed));

            Assert.IsNotEmpty(retweetResult.Id.ToString());
            Assert.AreEqual(retweetResult.Text, "RT @Hanna74046784: Test");

            var unretweetResponse = retweet.PostUnReTweet();
            var unretweetResult = deserialize.DeserialiseResponse<PostRetweetModel>(unretweetResponse);

            Assert.IsNotEmpty(unretweetResult.Id.ToString());
            Assert.AreEqual(unretweetResult.Text, "Test");
        }
    }
}
