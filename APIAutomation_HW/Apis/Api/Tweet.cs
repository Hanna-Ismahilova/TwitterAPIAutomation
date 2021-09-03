using RestSharp;


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

        public IRestResponse DeleteTweet(ulong id)
        { 
            var request = new RestRequest("1.1/statuses/destroy/{:id}.json", Method.POST);
            request.AddUrlSegment(":id", id);
            return GetResponse(request);
        }

        public IRestResponse GetResponseOfResource(string apiResource)
        {
            var request = new RestRequest
            {
                Resource = apiResource
            };
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute(request);
        }

        //TODO: Assert move to test > arrange/act/assert approach
    }
}

