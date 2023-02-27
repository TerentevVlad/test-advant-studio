namespace Saves
{
    public class DBAdapter<T> where T : Data, new()
    {
        private readonly DataBase _dataBase;

        public DBAdapter(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        
        protected T Get(string key)
        {
            return _dataBase.GetData<T>(key);
        }

        protected void Set(string key, T value)
        {
            _dataBase.SetData(key, value);
        }
    }
}