namespace AppliancesModel.Contracts
{
    public interface IDataSerialization
    {
        void SerializeAndSave<T>(T data);
        T GetDeserializedDataOrDefault<T>(string filename);
    }
}
