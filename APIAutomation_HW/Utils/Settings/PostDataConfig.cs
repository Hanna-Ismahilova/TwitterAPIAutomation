using APIAutomation_HW.Apis.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace APIAutomation_HW
{
   public class PostDataConfig
    {
        public CreateANewTweetModel CreateANewTweetModel { get; set; }


        public PostDataConfig()
        {
            using var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/createanewtweet.json");

            CreateANewTweetModel = JsonConvert.DeserializeObject<CreateANewTweetModel>(stream.ReadToEnd());

            //using var stream2 = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/home_timeline.json");

            //CreateANewTweetModel = JsonConvert.DeserializeObject<CreateANewTweetModel>(stream.ReadToEnd());


        }

    }
}
