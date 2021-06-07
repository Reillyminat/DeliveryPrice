using AppliancesModel.Contracts;
using System.IO;
namespace AppliancesModel
{
    public class DataSerialization : IDataSerialization
    {
        public string Filename { get; set; }

        public void SerializeToFile<T>(T data) where T : class
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(data.GetType().Name + ".json"))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data, typeof(T));
            }
        }

        public T DeserializeFromFileOrDefault<T>(string filename) where T : class
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
