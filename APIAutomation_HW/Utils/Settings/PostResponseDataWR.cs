using APIAutomation_HW.Apis.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace APIAutomation_HW
{
   public class PostResponseDataWR
    {
        public PostNewTweetModel CreateANewTweetModel { get; set; }

        public PostResponseDataWR()
        {

            using var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/createanewtweet.json");

            CreateANewTweetModel = JsonConvert.DeserializeObject<PostNewTweetModel>(stream.ReadToEnd());

        }
    }
}
