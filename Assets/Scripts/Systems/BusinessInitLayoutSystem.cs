using System.Collections.Generic;
using Installers;
using Layouts;
using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class BusinessBuySystem : IEcsRunSystem
    {
        private EcsFilter<LevelComponent, BuyBusinessComponent> _businessComponentFilter;
        public void Run()
        {
            foreach (var index in _businessComponentFilter)
            {
                ref var entity = ref _businessComponentFilter.GetEntity(index);
                
                ref var levelComponent = ref _businessComponentFilter.Get1(index);
                ref var command = ref _businessComponentFilter.Get2(index);


                levelComponent.Level++;
                
                
                entity.Del<BuyBusinessComponent>();
            }
        }
    }
    
    public class BusinessInitLayoutSystem : IEcsInitSystem
    {
        private EcsFilter<BusinessComponent> _businessComponentFilter;
        
        private BusinessLayoutConfig _layoutConfig;
        private EcsWorld _world;
        public void Init()
        {
            foreach (var index in _businessComponentFilter)
            {
                ref var entity = ref _businessComponentFilter.GetEntity(index);
                ref var businessComponent = ref _businessComponentFilter.Get1(index);

                var layout = InstantiatePrefab();
                
                
                ref var businessPresenterComponent = ref entity.Get<BusinessPresenterComponent>();
                
                businessPresenterComponent.Presenter = new BusinessLayoutPresenter(layout);
                businessPresenterComponent.Presenter.Init(businessComponent);
                businessPresenterComponent.Presenter.AddBuyClickListener(() =>
                {
                    ref var e = ref _businessComponentFilter.GetEntity(index);
                    ref var buyCommandComponent = ref e.Get<BuyBusinessComponent>();
                });
            }
        }

        private BusinessLayout InstantiatePrefab()
        {
            return Object.Instantiate(_layoutConfig.Prefab, _layoutConfig.ContentLayout);
        }
    }
}