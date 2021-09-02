
using NUnit.Framework;
using SwaggerPetstore_APIAutomation_Framework.Apis.Models;

namespace SwaggerPetstore_APIAutomation_Framework.Steps.ApiSteps
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures), Category("Pet")]

    public class PostSinglePet : BaseApiTests
    {
        [SetUp]
        public void Setup()
        {
            SetBaseUriAndAuth();
        }

        [Test, Description("Endpoint: /pet. Used: Authentication to Swagger Pet")]
        public void POST_SinglePet()
        {
            string payload = @"{
" + "\n" +
@"  ""id"": 1,
" + "\n" +
@"  ""category"": {
" + "\n" +
@"    ""id"": 0,
" + "\n" +
@"    ""name"": ""string""
" + "\n" +
@"  },
" + "\n" +
@"  ""name"": ""My lovely doggie"",
" + "\n" +
@"  ""photoUrls"": [
" + "\n" +
@"    ""string""
" + "\n" +
@"  ],
" + "\n" +
@"  ""tags"": [
" + "\n" +
@"    {
" + "\n" +
@"      ""id"": 0,
" + "\n" +
@"      ""name"": ""string""
" + "\n" +
@"    }
" + "\n" +
@"  ],
" + "\n" +
@"  ""status"": ""available""
" + "\n" +
@"}";
            NewPet.PostPet(payload);

            //NewPet.AssertTweetWasPosted(1, "My lovely doggie");
        }


    }
}
