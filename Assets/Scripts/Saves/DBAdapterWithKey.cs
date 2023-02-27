namespace Saves
{
    public class DBAdapterWithKey<T> : DBAdapter<T> where T : Data, new()
    {
        private readonly string _key;
        
        public DBAdapterWithKey(string key, DataBase dataBase) : base(dataBase)
        {
            _key = key;
        }
        
        public T Get()
        {
            return Get(_key);
        }

        public void Set(T value)
        {
            Set(_key, value);
        }
    }
}