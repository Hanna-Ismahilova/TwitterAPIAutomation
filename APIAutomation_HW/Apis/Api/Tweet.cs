using APIAutomation_HW.Apis.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace APIAutomation_HW.Apis
{
    public class Tweet : BaseApiTests
    {

        public IRestResponse PostTweet(string message)
        {
            var request = new RestRequest("1.1/statuses/update.json", Method.POST);
            request.AddParameter("status", message, ParameterType.GetOrPost);
            return GetResponse(request);
        }

        public IRestResponse GetResponseOfResource(string apiResource)
        {
            var request = new RestRequest();
            request.Resource = apiResource;
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute(request);
        }

        private T DeserialiseResponse<T>(IRestResponse response)
        {
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            return jsonDeserializer.Deserialize<T>(response);
        }

        public void AssertTweetWasPosted(string tweet, IRestResponse response)
        {
            var result = DeserialiseResponse<List<CreateANewTweetModel>>(response);
            Assert.True(result.First().Text == tweet);
        }
    }
}

