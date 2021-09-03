using APIAutomation_HW.Apis.Models;
using RestSharp;
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

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<List<GetUserByIdModel>>(request);
        }
    }
}
