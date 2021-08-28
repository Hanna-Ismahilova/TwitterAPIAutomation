using APIAutomation_HW.Apis.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis
{
    public class Tweet : BaseApiTests
    {
        public static void PostTweet(string message)
        {
            Request = new RestRequest("/1.1/statuses/update.json", Method.POST);
            Request.AddParameter("status", message, ParameterType.GetOrPost);
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
            JsonDeserializer jsonDeserializer = new();
            return jsonDeserializer.Deserialize<T>(Response);
        }

        public static void AssertTweetWasPosted(string tweet)
        {
            var result = DeserialiseResponse<List<HomeTimeline>>();
            Assert.True(result[0].Text == tweet);
        }
    }
}
