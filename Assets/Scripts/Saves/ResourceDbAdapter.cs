namespace Saves
{
    public class ResourceDbAdapter : DBAdapterWithKey<ResourcesData>
    {
        public ResourceDbAdapter(string key, DataBase dataBase) : base(key, dataBase)
        {
            
        }
    }
}