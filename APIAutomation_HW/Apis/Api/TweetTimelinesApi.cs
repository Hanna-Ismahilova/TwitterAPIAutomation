using APIAutomation_HW.Apis.Models;
using RestSharp;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis.Api
{
    public class TweetTimelinesApi : BaseApiTests
    {
        public IRestResponse GetTweetHomeTimeline()
        {
            var request = new RestRequest("/1.1/statuses/home_timeline.json", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<GetTweetHomeTimelineModel>(request);
        }
    }
}
