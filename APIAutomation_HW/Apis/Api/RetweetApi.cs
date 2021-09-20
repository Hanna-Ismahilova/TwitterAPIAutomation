using RestSharp;

namespace APIAutomation_HW.Apis.Api
{
    public class RetweetApi : BaseApi
    {
        public IRestResponse PostReTweet()
        {
            var request = new RestRequest("/1.1/statuses/retweet/1431598792743301128.json", Method.POST);
            return GetResponse(request);
        }

        public IRestResponse PostUnReTweet()
        {
            var request = new RestRequest("/1.1/statuses/unretweet/1431598792743301128.json", Method.POST);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute(request);
        }
    }
}
