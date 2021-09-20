using RestSharp;

namespace APIAutomation_HW.Apis.Api
{
    public class FavoriteTweetApi : BaseApi
    {
        public IRestResponse PostTweetToFavorite()
        {
            var request = new RestRequest("/1.1/favorites/create.json?id=1431598792743301128", Method.POST);
            return GetResponse(request);
        }

        public IRestResponse DeleteTweetFromFavorite()
        {
            var request = new RestRequest("/1.1/favorites/destroy.json?id=1431598792743301128", Method.POST);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute(request);
        }

    }

}
