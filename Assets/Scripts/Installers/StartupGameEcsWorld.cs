using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DefaultNamespace;
using DefaultNamespace.Configs;
using Layouts;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Saves;
using Systems;

namespace Installers
{
    public class StartupGameEcsWorld : IDisposable
    {
        private readonly List<BusinessConfig> _businessConfigs;
        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;

        public StartupGameEcsWorld(List<BusinessConfig> businessConfigs,
            BusinessLayoutConfig businessLayoutConfig, PlayerResourceContainer playerResourceContainer,
            Dictionary<BusinessConfig, BusinessDbAdapter> businessDbAdapters)
        {
            _businessConfigs = businessConfigs;



            _world = new EcsWorld();

#if UNITY_EDITOR
            EcsWorldObserver.Create (_world);
#endif  

            _initSystems = new EcsSystems(_world);
            _initSystems.Add(new BusinessInitSystem());
            _initSystems.Add(new BusinessInitLayoutSystem());
            _initSystems.Inject(_businessConfigs);
            _initSystems.Inject(businessLayoutConfig);
            _initSystems.Inject(playerResourceContainer);
            _initSystems.Inject(businessDbAdapters);

            _initSystems.Init();



            _updateSystems = new EcsSystems(_world);
            
            _updateSystems.Add(new BusinessUpgradeSystem());
            _updateSystems.Add(new BusinessLevelSystem());
            _updateSystems.Add(new BusinessIncomeSystem());


            _updateSystems.Add(new BusinessProductionProcessSystem());
            _updateSystems.Add(new BusinessPresenterSystem());
            _updateSystems.Add(new BusinessProductionPresenterSystem());
            _updateSystems.Add(new BusinessIncomePresenterSystem());
            _updateSystems.Inject(playerResourceContainer);
            _updateSystems.Inject(businessDbAdapters);

            _updateSystems.Init();
        }
        
        public void Update()
        {
            _updateSystems?.Run();
        }

        public void Dispose()
        {
            _initSystems.Destroy();
            _world.Destroy();
        }
    }
}