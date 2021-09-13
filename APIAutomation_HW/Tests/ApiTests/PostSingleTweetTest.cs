using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIAutomation_HW.Steps.ApiSteps
{
    [TestFixture, Category("API_Smoke")]

    public class PostSingleTweetTest : BaseApiTests
    {
        [Category("Tweet")]

        [SetUp]
        public void Setup()
        {         
            AuthTwitter();
        }

        [Test, Order(1), Description("Endpoint: /1.1/statuses/update.json. Used: Authentication to Twitter")]
        public void POST_DELETE_SingleTweet()
        {
            var tweetPost = new PostResponseDataWR();
            var deserialize = new CommonMethods();

            var tweet = new TweetApi();
            var response = tweet.PostTweet(tweetPost.CreateANewTweetModel.Text);

            var result = deserialize.DeserialiseResponse<List<PostNewTweetModel>>(response);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
            Assert.AreEqual(result.First().Text, "Hello Twitter!");

            var responseDelete = tweet.DeleteTweet((result.First().Id));
            //deserialize.DeserialiseResponse<List<DeleteTweetModel>>(responseDelete); // needed to check deletion 
            Assert.That(responseDelete.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
        }

        [Test, Order(2), Description("Endpoint: /1.1/statuses/update.json. Used: Authentication to Twitter")]
        public void POST_DuplicateTweet()
        {
            var tweetDupPost = new DuplicatePostDataWR();
            var deserialize = new CommonMethods();

            var tweet = new TweetApi();
            var response = tweet.PostTweet(tweetDupPost.DuplicateTweetModel.Text);

            deserialize.DeserialiseResponse<List<PostDuplicateTweetModel>>(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }
    }
}
