using RestSharp;


namespace APIAutomation_HW.Apis
{
    public class TweetApi : BaseApi
    {
        public IRestResponse PostTweet(string message)
        {
            var request = new RestRequest("1.1/statuses/update.json", Method.POST);
            request.AddParameter("status", message, ParameterType.GetOrPost);
            return GetResponse(request);
        }

        public IRestResponse DeleteTweet(ulong id)
        { 
            var request = new RestRequest("1.1/statuses/destroy/{:id}.json", Method.POST);
            request.AddUrlSegment(":id", id);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute(request);
        }
    }
}

