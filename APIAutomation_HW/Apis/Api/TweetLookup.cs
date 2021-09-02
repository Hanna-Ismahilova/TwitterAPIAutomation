using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis
{
    public class TweetLookup : BaseApiTests
    {
        readonly CommonMethods deserialize = new();
        public IRestResponse GetSingleTweet()
        {
            var request = new RestRequest("/2/tweets/1431598792743301128", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<List<GetUserByIdModel>>(request);
        }

        public void AssertGetResponse(string id, string text, IRestResponse response)
        {
            var output = deserialize.DeserialiseResponse<GetTweetModel>(response);
            
            var tweetId = output.Data?.Id; //null check "?". do that for each test
            var tweetTitleText = output.Data?.Text;

            Assert.That(tweetId, Is.EqualTo(id));
            Assert.That(tweetTitleText, Is.EqualTo(text));    
        }
    }
}
