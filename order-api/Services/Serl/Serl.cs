using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace order_api.Services.Serl
{
    public class NewtonSoftService : ISerializerService
    {
        public T? Deserialize<T>(string text)
        {
            T? t = JsonConvert.DeserializeObject<T>(text);
            return t;
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>
                {
                     new StringEnumConverter(new CamelCaseNamingStrategy())
                }
            });
        }

        public string Serialize<T>(T obj, Type type)
        {
            return JsonConvert.SerializeObject(obj, type, new());
        }
    }

    public interface ISerializerService : IServerService
    {
        string Serialize<T>(T obj);

        string Serialize<T>(T obj, Type type);

        T? Deserialize<T>(string text);
    }
}
