using APIAutomation_HW.Apis.Models;
using RestSharp;

namespace APIAutomation_HW.Apis.Api
{
    public class TweetHomeTimelineApi : BaseApi
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
