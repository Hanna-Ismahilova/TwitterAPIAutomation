﻿using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Category("API_Smoke")]
    public class GetTweetHomeTimelineTest : BaseApi
    {
        [Category("Tweet_Home_Timeline")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Description("Endpoint: /1.1/statuses/home_timeline.json. Used: Authentication to Twitter")]
        public void GET_TweetHomeTimeline()
        {
            var deserialize = new CommonMethods();
            var tweetHomeTimeline = new TweetHomeTimelineApi();

            var response = tweetHomeTimeline.GetTweetHomeTimeline();
            var output = deserialize.DeserialiseResponse<List<GetTweetHomeTimelineModel>>(response);

            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.IsNotEmpty(output.FirstOrDefault().Text);
        }
    }
}
