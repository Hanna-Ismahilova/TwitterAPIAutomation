using APIAutomation_HW.Apis.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace APIAutomation_HW
{
   public class DuplicatePostDataWR
    {
        public PostDuplicateTweetModel DuplicateTweetModel { get; set; }


        public DuplicatePostDataWR()
        {
            using var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/duplicatepost.json");

            DuplicateTweetModel = JsonConvert.DeserializeObject<PostDuplicateTweetModel>(stream.ReadToEnd());
        }

    }
}
