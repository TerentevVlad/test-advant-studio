using System;
using System.Collections.Generic;
using System.Linq;

namespace Saves
{
    [Serializable]
    public class ResourcesData : Data
    {
        public List<ResourceData> Resources;

        public ResourcesData()
        {
            Resources = new List<ResourceData>();
        }

        public double GetValueByKey(string resourceKey)
        {
            var resourceData = Resources.FirstOrDefault(v => v.Key == resourceKey);
            return resourceData != null ? resourceData.Value : 0;
        }
    }
}