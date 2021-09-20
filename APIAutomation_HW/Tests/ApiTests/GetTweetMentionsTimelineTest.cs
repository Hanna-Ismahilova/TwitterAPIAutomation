using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Category("API_Smoke")]

    public class GetTweetMentionsTimelineTest : BaseApi
    {
        [Category("Tweet_Mentions_Timeline")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Description("Endpoint: /1.1/statuses/mentions_timeline.json. Used: Authentication to Twitter")]
        public void GET_TweetMentionsTimeline()
        {
            var deserialize = new CommonMethods();
            var tweetMentionsTimeline = new TweetMentionsTimelineApi();

            var response = tweetMentionsTimeline.GetTweetMentionsTimeline();
            var output = deserialize.DeserialiseResponse<List<GetTweetMentionTimelineModel>>(response);

            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.AreEqual(output.FirstOrDefault().Text, "@Hanna74046784 Mention post");
        }

    }
}
