using APIAutomation_HW.Apis.Models;
using RestSharp;

namespace APIAutomation_HW.Apis.Api
{
    public class TweetMentionsTimelineApi : BaseApi
    {
        public IRestResponse GetTweetMentionsTimeline()
        {
            var request = new RestRequest("/1.1/statuses/mentions_timeline.json", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<GetTweetMentionTimelineModel>(request);
        }
    }
}
