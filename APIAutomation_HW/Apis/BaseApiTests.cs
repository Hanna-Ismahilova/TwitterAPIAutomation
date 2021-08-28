using APIAutomation_HW.Utils.Settings;
using RestSharp;
using RestSharp.Authenticators;

namespace APIAutomation_HW.Apis
{
    public class BaseApiTests : Settings
    {
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl)
            {
                Authenticator = AuthTwitter()
            };
        }

        public static OAuth1Authenticator AuthTwitter()
        {
            OAuth1Authenticator oAuth1Authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            
            return oAuth1Authenticator;
        }



    }
}
