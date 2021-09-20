using APIAutomation_HW.Utils.Settings;
using RestSharp;
using RestSharp.Authenticators;

namespace APIAutomation_HW.Apis
{
    public class BaseApi : AppSettings
    {
        public RestClient Client;

        public BaseApi()
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
