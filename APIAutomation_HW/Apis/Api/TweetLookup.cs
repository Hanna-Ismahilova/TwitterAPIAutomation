using APIAutomation_HW.Apis.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis
{
    public class TweetLookup : BaseApiTests
    {
        public IRestResponse GetSingleTweet()
        {
            var request = new RestRequest("/2/tweets/1431598792743301128", Method.GET);
            return GetResponse(request);
        }

        //TODO: move to CommonMethods

        private IRestResponse GetResponse(IRestRequest request)
        {

            return Client.Execute<List<GetUserByIdModel>>(request);

        }

        //TODO: move to CommonMethods
        private T DeserialiseResponse<T>(IRestResponse response)
        {
            var deserialize = new JsonSerializer();
            return deserialize.Deserialize<T>(response);
           
        }


        public void AssertGetResponse(string id, string text, IRestResponse response)
        {
            var output = DeserialiseResponse<GetTweetModel>(response);
            
            var tweetId = output.Data?.Id; //null check "?". do that for each test
            var tweetTitleText = output.Data?.Text;

            Assert.That(tweetId, Is.EqualTo(id));
            Assert.That(tweetTitleText, Is.EqualTo(text));    
        }



    }
}
