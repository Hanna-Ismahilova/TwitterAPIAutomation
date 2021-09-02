using SwaggerPetstore_APIAutomation_Framework.Apis.Models.Apis.Models;
using System.Collections.Generic;

namespace SwaggerPetstore_APIAutomation_Framework.Apis.Models
{
    public class PostANewPetModel : PhotoUrlsBase
    {
        public int Id { get; set; }
        public CategoryDataModel Category { get; set; }
        public string Name { get; set; }
        public List<TagBase> Tags { get; set; }
        public string Status { get; set; }
        public List<PhotoUrlsBase> PhotoUrlsBase { get; set; }
    }
}


