using RestSharp;

namespace APIAutomation_HW.Apis.Api
{
    public class UserLookup : BaseApiTests
    {
        public static void GetUserById()
        {
            Request = new RestRequest("/2/users/2244994946", Method.GET);
            GetResponse();
        }

        private static void GetResponse()
        {

            Response = Client.Execute(Request);

        }
    }
}
