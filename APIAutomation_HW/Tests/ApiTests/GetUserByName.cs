﻿using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using NUnit.Framework;

namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("API_Smoke")]
    public class GetUserByName : BaseApiTests
    {
        [Category("User_Lookup")]

        [SetUp]
        public void Setup()
        {
            AuthTwitter();
        }

        [Test, Description("Endpoint: 2/users/{:id}. Used: Authentication to Twitter")]
        public void GET_UserByName_200_NotFound()
        {
            var userLookup = new UserLookup();
            var response = userLookup.GetUserByUsername_NotFound();

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(RestSharp.ResponseStatus.Completed));

            userLookup.AssertGetResponse_GetUserByUsername_NotFound("Could not find user with username: [TwitterDec].", "Not Found Error", "TwitterDec", "TwitterDec", response);
        }
    }
}

