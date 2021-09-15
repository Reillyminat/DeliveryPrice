using Newtonsoft.Json;

namespace AppliancesModel
{
    public static class JsonSerialization
    {
        public static T CreateDeepCopy<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return JsonConvert.DeserializeObject<T>(serialized, new JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
        }
    }
}
