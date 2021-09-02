
using RestSharp;
using SwaggerPetstore_APIAutomation_Framework.Utils.Settings;

namespace SwaggerPetstore_APIAutomation_Framework
{
    public class BaseApiTests : Settings
    {
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl);
        }

        //public static SimpleAuthenticator AuthToPetStore()
        //{
        //    SimpleAuthenticator authenticator = SimpleAuthenticator(apiKey, apiKeyValue);
            
        //    return oAuth1Authenticator;
        //}



    }
}
