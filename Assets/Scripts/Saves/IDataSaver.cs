namespace Saves
{
    public interface IDataSaver
    {
        public void SaveData(string key, object data);
        public T LoadData<T>(string key) where T : Data;
    }
}