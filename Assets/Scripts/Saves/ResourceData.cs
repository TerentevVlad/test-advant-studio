using System;

namespace Saves
{
    [Serializable]
    public class ResourceData
    {
        public string Key;
        public double Value;

        public ResourceData()
        {
            Key = "";
            Value = 0;
        }
    }
}