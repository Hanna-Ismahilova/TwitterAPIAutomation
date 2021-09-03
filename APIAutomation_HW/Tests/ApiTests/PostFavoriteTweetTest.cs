using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("API_Smoke")]

    public class PostFavoriteTweetTest : BaseApiTests
    {
        [Category("Tweet")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Order(1), Description("Endpoint: /1.1/favorites/create.json?id={id}, 1.1/favorites/destroy.json?id={id} . Used: Authentication to Twitter")]
        public void POST_TweetToFromFavorite()
        {
            var deserialize = new CommonMethods();
            var favoriteTweet = new FavoriteTweetApi();

            var favoriteTweetResponse = favoriteTweet.PostTweetToFavorite();
            var favoriteTweetResult = deserialize.DeserialiseResponse<PostFavoriteTweetModel>(favoriteTweetResponse);

            Assert.That(favoriteTweetResponse.Content, Is.Not.Empty);
            Assert.That(favoriteTweetResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(favoriteTweetResponse.ResponseStatus.Equals(ResponseStatus.Completed));

            Assert.True(favoriteTweetResult.Favorited);

            var deleteFavoriteTweetResponse = favoriteTweet.DeleteTweetFromFavorite();
            var deletedFavoriteTweetResult = deserialize.DeserialiseResponse<PostFavoriteTweetModel>(deleteFavoriteTweetResponse);

            Assert.False(deletedFavoriteTweetResult.Favorited);
        }
    }
}
