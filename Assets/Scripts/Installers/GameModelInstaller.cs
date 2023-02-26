using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Configs;
using UnityEngine;

namespace Installers
{
    public class GameModelInstaller : MonoBehaviour
    {
        [SerializeField] private List<BusinessConfig> _businessConfigs;
        [SerializeField] private BusinessLayoutConfig _businessLayoutConfig;
        [SerializeField] private PlayerResourceConfigs _playerResourceConfigs;
        
        private StartupGameEcsWorld _startupGameEcsWorld;
      
        private void Awake()
        {
            _startupGameEcsWorld = new StartupGameEcsWorld(
                _businessConfigs,
                _businessLayoutConfig,
                _playerResourceConfigs);
        }

        private void Update()
        {
            _startupGameEcsWorld.Update();
        }

        private void OnDestroy()
        {
            _startupGameEcsWorld.Dispose();
        }
    }
}