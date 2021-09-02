using APIAutomation_HW.Apis;
using NUnit.Framework;

namespace APIAutomation_HW.Steps
{
    [TestFixture, Category("API_Smoke")]

    public class GetTweet : BaseApiTests

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
            
            var tweetLookup = new TweetLookup();
            var response = tweetLookup.GetSingleTweet();

            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));

            tweetLookup.AssertGetResponse("1431598792743301128", "Test", response);
        }
    }
}
