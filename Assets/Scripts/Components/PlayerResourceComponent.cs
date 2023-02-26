using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resource;
using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public struct PlayerResourceComponent
    {
        public List<Resource> Resources;
        public Resource GetResource(string key) => Resources.FirstOrDefault(v => v.ResourceConfig.Key == key);
    }

    public class PlayerResourceInitSystem : IEcsInitSystem
    {
        private PlayerResourceConfigs _playerResourceConfigs;
        private EcsWorld _world;
        public void Init()
        {
            var playerResourceEntity = _world.NewEntity();
            ref var playerResourceComponent = ref playerResourceEntity.Get<PlayerResourceComponent>();

            playerResourceComponent.Resources = new List<Resource>();
            foreach (var resourceConfig in _playerResourceConfigs.Resources)
            {
                Resource resource = new Resource
                {
                    Value = resourceConfig.InitValue,
                    ResourceConfig = resourceConfig
                };
                playerResourceComponent.Resources.Add(resource);
            }
        }
    }

    [Serializable]
    public class PlayerResourceConfigs
    {
        [SerializeField] private List<ResourceConfig> _resources;

        public List<ResourceConfig> Resources => _resources;
    }
}