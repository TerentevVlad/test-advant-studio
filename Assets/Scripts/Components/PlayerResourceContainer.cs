using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resource;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerResourceContainer
    {
        private readonly List<Resource> _resources;

        public event Action<Resource> OnValueChanged; 
        public PlayerResourceContainer(PlayerResourceConfigs playerResourceConfigs)
        {
            _resources = new List<Resource>();
            foreach (var config in playerResourceConfigs.Resources)
            {
                _resources.Add(new Resource()
                {
                    ResourceConfig =  config,
                    Value = config.InitValue
                });
            }
        }

        public IReadOnlyList<Resource> Resources => _resources;
        public Resource GetResource(string key) => _resources.FirstOrDefault(v => v.ResourceConfig.Key == key);

        public void Subtract(ResourceConfig resourceConfig, double value)
        {
            var resource = GetResource(resourceConfig.Key);
            resource.Value -= value;
            OnValueChanged?.Invoke(resource);
        }

        public void AddSoft(double value)
        {
            var resource = GetResource("resource/soft");
            resource.Value += value;
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