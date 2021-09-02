using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SwaggerPetstore_APIAutomation_Framework.Apis.Models;
using System.Collections.Generic;

namespace SwaggerPetstore_APIAutomation_Framework
{
    public class NewPet : BaseApiTests
    {
        public static void PostPet(string body)
        {
            Request = new RestRequest("/pet", Method.POST);
            Request.AddHeader("api_key", "special-key");
            Request.AddHeader("Content-Type", "application/json");
            Request.AddParameter("application/json", body, ParameterType.RequestBody);

            GetResponse();
        }

        public static void GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest();
            Request.Resource = apiResource;
            GetResponse();
        }

        private static void GetResponse()
        {
            Response = Client.Execute(Request);
        }

        private static T DeserialiseResponse<T>()
        {
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            return jsonDeserializer.Deserialize<T>(Response);
        }

        public static void AssertTweetWasPosted(int id, string name, List<PhotoUrlsBase> photoUrls)
        {
            var output = DeserialiseResponse<PostANewPetModel> ();

            var petId = output.Id;
            var petName = output.Name;
            var url = output.PhotoUrls;

            Assert.That(petId, Is.EqualTo(id));
            Assert.That(petName, Is.EqualTo(name));
            Assert.That(url, Is.EqualTo(photoUrls));
           
            
        }
    }
}

