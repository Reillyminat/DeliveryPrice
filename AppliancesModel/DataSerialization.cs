using AppliancesModel.Contracts;
using System.IO;
namespace AppliancesModel
{
    public class DataSerialization : IDataSerialization
    {
        public void SerializeAndSave<T>(T data)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
            using var streamWriter = new StreamWriter(data.GetType().Name + ".json");
            using var jsonWriter = new Newtonsoft.Json.JsonTextWriter(streamWriter);
            serializer.Serialize(jsonWriter, data, typeof(T));
        }

        public T GetDeserializedDataOrDefault<T>(string filename)
        {
            if (File.Exists(filename))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(File.ReadAllText(filename), new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                });

                return obj;
            }
            else return default(T);
        }
    }
}
