using RestSharp;
using RestSharp.Serialization.Json;

namespace APIAutomation_HW.Utils.CommonMethods
{
    public class CommonMethods
    {
        public T DeserialiseResponse<T>(IRestResponse response)
        {
            JsonDeserializer deserialize = new();
            return deserialize.Deserialize<T>(response);
        }
    }
}
