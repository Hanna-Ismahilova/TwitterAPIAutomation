using APIAutomation_HW.Apis.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis
{
    public class TweetLookup : BaseApiTests
    {
        public static void GetSingleTweet()
        {
            Request = new RestRequest("/2/tweets/1431598792743301128", Method.GET);
            GetResponse();
        }

        public static void GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest
            {
                Resource = apiResource
            };
            GetResponse();
        }

        private static void GetResponse()
        {

            Response = Client.Execute(Request);

        }

        private static T DeserialiseResponse<T>()
        {
            var deserialize = new JsonDeserializer();
            return deserialize.Deserialize<T>(Response);
           
        }


        public static void AssertGetResponse(string id, string text)
        {
            var output = DeserialiseResponse<List<GetTweetModel>>();
            var tweetId = output[0].Id;
            var tweetTitleText = output[1].Text;

            Assert.That(tweetId, Is.EqualTo(id));
            Assert.That(tweetTitleText, Is.EqualTo(text));    

        }

    }
}
