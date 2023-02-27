namespace Saves
{
    
    public class DataBase
    {
        private readonly SaveService _saveService;
        public DataBase()
        {
            _saveService = new SaveService(new DataSaverToPlayerPrefs());
        }

        public T GetData<T>(string key) where T : Data, new()
        {
            var data = _saveService.LoadData<T>(key);
            if (data == null)
                data = new T();
            return data;
        }

        public void SetData<T>(string key, T value) where T : Data, new()
        {
            _saveService.SaveData(key, value);
        }
    }
}