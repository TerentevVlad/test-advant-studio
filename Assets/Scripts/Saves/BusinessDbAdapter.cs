namespace Saves
{
    public class BusinessDbAdapter : DBAdapterWithKey<BusinessData>
    {
        public BusinessDbAdapter(string key, DataBase dataBase) : base(key, dataBase)
        {
            
        }
    }
}