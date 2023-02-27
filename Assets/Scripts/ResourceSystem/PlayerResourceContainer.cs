using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resource;
using Saves;
using UnityEngine;

namespace ResourceSystem
{
    public class PlayerResourceContainer
    {
        private readonly ResourceDbAdapter _resourceDbAdapter;
        private readonly List<Resource> _resources;

        public event Action<Resource> OnValueChanged; 
        public PlayerResourceContainer(PlayerResourceConfigs playerResourceConfigs, ResourceDbAdapter resourceDbAdapter)
        {
            _resourceDbAdapter = resourceDbAdapter;
            _resources = new List<Resource>();

            var resourcesData = resourceDbAdapter.Get();
            if (resourcesData.Resources.Count == 0)
            {
                foreach (var config in playerResourceConfigs.Resources)
                {
                    _resources.Add(new Resource()
                    {
                        ResourceConfig = config,
                        Value = config.InitValue
                    });
                    
                    _resourceDbAdapter.Set(ConvertResourcesToResourceData());
                }
            }
            else
            {
                foreach (var config in playerResourceConfigs.Resources)
                {
                    _resources.Add(new Resource()
                    {
                        ResourceConfig = config,
                        Value =  resourcesData.GetValueByKey(config.Key)
                    });
                }
            }
        }

        private ResourcesData ConvertResourcesToResourceData()
        {
            var resourcesData = new ResourcesData
            {
                Resources = new List<ResourceData>()
            };

            foreach (var resource in _resources)
            {
                resourcesData.Resources.Add(new ResourceData()
                {
                    Key =  resource.ResourceConfig.Key,
                    Value = resource.Value
                });
            }

            return resourcesData;

        }

        public IReadOnlyList<Resource> Resources => _resources;
        public Resource GetResource(string key) => _resources.FirstOrDefault(v => v.ResourceConfig.Key == key);

        public void Subtract(ResourceConfig resourceConfig, double value)
        {
            var resource = GetResource(resourceConfig.Key);
            resource.Value -= value;
            
            _resourceDbAdapter.Set(ConvertResourcesToResourceData());
            OnValueChanged?.Invoke(resource);
        }

        public void AddSoft(double value)
        {
            var resource = GetResource("resource/soft");
            resource.Value += value;
            
            _resourceDbAdapter.Set(ConvertResourcesToResourceData());
            OnValueChanged?.Invoke(resource);
        }
    }

    
    [Serializable]
    public class PlayerResourceConfigs
    {
        [SerializeField] private List<ResourceConfig> _resources;

        public List<ResourceConfig> Resources => _resources;
    }
}