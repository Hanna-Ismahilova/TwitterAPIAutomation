using APIAutomation_HW.Apis.Models;
using RestSharp;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis
{
    public class TweetLookup : BaseApiTests
    {
        public IRestResponse GetSingleTweet()
        {
            var request = new RestRequest("/1.1/statuses/show/1431598792743301128.json", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<List<GetUserByIdModel>>(request);
        }
    }
}
