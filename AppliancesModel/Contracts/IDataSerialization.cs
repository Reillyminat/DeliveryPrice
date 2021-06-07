namespace AppliancesModel.Contracts
{
    public interface IDataSerialization
    {
        string Filename { get; set; }
        void SerializeToFile<T>(T data) where T : class;
        T DeserializeFromFileOrDefault<T>(string filename) where T : class;
    }
}
