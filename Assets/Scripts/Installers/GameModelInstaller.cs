using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Configs;
using Layouts;
using UnityEngine;

namespace Installers
{
    public class GameModelInstaller : MonoBehaviour
    {
        [SerializeField] private MainWindowLayout _mainWindowLayout;
        [SerializeField] private List<BusinessConfig> _businessConfigs;
        [SerializeField] private BusinessLayoutConfig _businessLayoutConfig;
        [SerializeField] private PlayerResourceConfigs _playerResourceConfigs;
        
        private StartupGameEcsWorld _startupGameEcsWorld;
      
        private void Awake()
        {
            PlayerResourceContainer playerResourceContainer = new PlayerResourceContainer(_playerResourceConfigs);

            MainWindowPresenter mainWindowPresenter = new MainWindowPresenter(playerResourceContainer, _mainWindowLayout);
            
            
            _startupGameEcsWorld = new StartupGameEcsWorld(
                _businessConfigs,
                _businessLayoutConfig,
                playerResourceContainer);
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