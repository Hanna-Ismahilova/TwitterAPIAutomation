using APIAutomation_HW.Apis;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APIAutomation_HW.Steps.ApiSteps
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("Tweet")]

    public class PostSingleTweet : BaseApiTests
    {
        [SetUp]
        public void Setup()
        {
            SetBaseUriAndAuth();
            AuthTwitter();
        }

        [Test, Description("Endpoint: /1.1/statuses/update.json. Used: Authentication to Twitter")]
        public static void POST_SingleTweet()
        {
            Tweet.PostTweet(message: "");
            Tweet.GetResponseOfResource(apiResource: "");
            Tweet.AssertTweetWasPosted(tweet: "");
        }


    }
}
