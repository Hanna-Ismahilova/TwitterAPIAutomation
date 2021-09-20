using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using RestSharp;
using System.Collections.Generic;

namespace APIAutomation_HW.Apis.Api
{
    public class UserLookupApi : BaseApi
    {
        public IRestResponse GetUserById_NotFound()
        {
            var request = new RestRequest("/2/users/2244994946", Method.GET);
            return GetResponse(request);
        }

        public IRestResponse GetUserById_DefaultPayload()
        {
            var request = new RestRequest("/2/users/2244994945", Method.GET);
            return GetResponse(request);
        }

        public IRestResponse GetUserByUsername_NotFound()
        {
            var request = new RestRequest("2/users/by/username/TwitterDec", Method.GET);
            return GetResponse(request);
        }

        private IRestResponse GetResponse(IRestRequest request)
        {
            return Client.Execute<List<GetUserByIdModel>>(request);
        }
    }
}
