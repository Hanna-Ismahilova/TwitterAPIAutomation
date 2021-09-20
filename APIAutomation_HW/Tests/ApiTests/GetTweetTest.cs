using APIAutomation_HW.Apis;
using NUnit.Framework;
using System.Net;
using RestSharp;
using APIAutomation_HW.Utils.CommonMethods;
using APIAutomation_HW.Apis.Models;

namespace APIAutomation_HW.Steps
{
    [TestFixture, Category("API_Smoke")]

    public class GetTweetTest : BaseApi

    {
        [Category("Tweet_Lookup")]
       

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Description("Endpoint: /tweets/{:id}. Used: Authentication to Twitter")]
        public void GET_SingleTweet()
        {
            var deserialize = new CommonMethods();
            var tweetLookup = new TweetLookupApi();
            
            var response = tweetLookup.GetSingleTweet();
            var output = deserialize.DeserialiseResponse<GetTweetDataModel>(response);

            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(ResponseStatus.Completed));

            Assert.That(output.Id, Is.EqualTo(1431598792743301128));
            Assert.AreEqual(output.Text, "Test");
        }
    }
}
