using Newtonsoft.Json;
using SwaggerPetstore_APIAutomation_Framework.Apis.Models;
using System;
using System.IO;

namespace SwaggerPetstore_APIAutomation_Framework
{
    public class PostDataConfig
    {
        public PostANewPetModel PetModel{ get; set; }


        public PostDataConfig()
        {
            using var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/createanewpet.json");

            PetModel = JsonConvert.DeserializeObject<PostANewPetModel>(stream.ReadToEnd());

            //using var stream2 = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/home_timeline.json");

            //CreateANewTweetModel = JsonConvert.DeserializeObject<CreateANewTweetModel>(stream.ReadToEnd());


        }

    }
}
