using APIAutomation_HW.Apis.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace APIAutomation_HW
{
   public class DuplicatePostWR
    {
        public DuplicateTweetModel DuplicateTweetModel { get; set; }


        public DuplicatePostWR()
        {
            using var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/duplicatepost.json");

            DuplicateTweetModel = JsonConvert.DeserializeObject<DuplicateTweetModel>(stream.ReadToEnd());
        }

    }
}
