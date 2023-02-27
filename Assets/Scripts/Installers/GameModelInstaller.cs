using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Configs;
using Layouts;
using Saves;
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
            DataBase dataBase = new DataBase();
            ResourceDbAdapter resourceDbAdapter = new ResourceDbAdapter("PlayerResources", dataBase);
            Dictionary<BusinessConfig, BusinessDbAdapter> businessDbAdapters = new Dictionary<BusinessConfig, BusinessDbAdapter>();
            foreach (var businessConfig in _businessConfigs)
            {
                businessDbAdapters.Add(businessConfig, new BusinessDbAdapter(businessConfig.Key, dataBase));
            }
            
            
            
            PlayerResourceContainer playerResourceContainer = new PlayerResourceContainer(_playerResourceConfigs, resourceDbAdapter);
            MainWindowPresenter mainWindowPresenter = new MainWindowPresenter(playerResourceContainer, _mainWindowLayout);
            
            
            _startupGameEcsWorld = new StartupGameEcsWorld(
                _businessConfigs,
                _businessLayoutConfig,
                playerResourceContainer,
                businessDbAdapters);
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