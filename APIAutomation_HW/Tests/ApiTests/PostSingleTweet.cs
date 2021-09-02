using APIAutomation_HW.Apis;
using NUnit.Framework;

namespace APIAutomation_HW.Steps.ApiSteps
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("Tweet")]

    public class PostSingleTweet : BaseApiTests
    {
        [SetUp]
        public void Setup()
        {         
            AuthTwitter();
        }

        [Test, Description("Endpoint: /1.1/statuses/update.json. Used: Authentication to Twitter")]
        public void POST_SingleTweet()
        {
            var tweetPost = new PostDataConfig();

            var tweet = new Tweet();
            var response = tweet.PostTweet(tweetPost.CreateANewTweetModel.Text);
            //tweet.GetResponseOfResource(response);
            tweet.AssertTweetWasPosted("Hello Twitter! This is my first created tweet via C#, RestSharp", response );
        }


    }
}
