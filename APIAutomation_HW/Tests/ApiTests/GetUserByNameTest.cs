using APIAutomation_HW.Apis;
using APIAutomation_HW.Apis.Api;
using APIAutomation_HW.Apis.Models;
using APIAutomation_HW.Utils.CommonMethods;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace APIAutomation_HW.Tests.ApiTests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("API_Smoke")]
    public class GetUserByNameTest : BaseApi
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
            var userLookup = new UserLookupApi();
            var deserialize = new CommonMethods();
            var response = userLookup.GetUserByUsername_NotFound();

            var output = deserialize.DeserialiseResponse<List<GetUserByIdModel>>(response);

            Assert.That(response.ErrorMessage, Is.Not.Empty);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ResponseStatus.Equals(ResponseStatus.Completed));

            Assert.AreEqual(output.First().Errors.First().Detail, "Could not find user with username: [TwitterDec].");
            Assert.AreEqual(output.First().Errors.First().Title, "Not Found Error");
            Assert.AreEqual(output.First().Errors.First().Value, "TwitterDec");
            Assert.AreEqual(output.First().Errors.First().Resource_id, "TwitterDec");         
        }
    }
}

