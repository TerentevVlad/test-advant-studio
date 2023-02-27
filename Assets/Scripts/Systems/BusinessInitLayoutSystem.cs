using Components;
using Components.EventComponents;
using Components.StateComponents;
using Configs;
using Layouts;
using Layouts.Presenters;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class BusinessInitLayoutSystem : IEcsInitSystem
    {
        private EcsFilter<BusinessComponent,ProductionComponent> _businessComponentFilter;
        
        private BusinessLayoutConfig _layoutConfig;
        private EcsWorld _world;
        
        public void Init()
        {
            foreach (var index in _businessComponentFilter)
            {
                ref var entity = ref _businessComponentFilter.GetEntity(index);
                ref var businessComponent = ref _businessComponentFilter.Get1(index);

                var layout = InstantiatePrefab();

                var businessConfig = businessComponent.BusinessConfig;
                
                ref var businessPresenterComponent = ref entity.Get<BusinessPresenterComponent>();
                
                businessPresenterComponent.Presenter = new BusinessLayoutPresenter(layout);
                businessPresenterComponent.Presenter.Init(businessComponent, _businessComponentFilter.Get2(index));
                businessPresenterComponent.Presenter.AddBuyClickListener(() =>
                {
                    ref var e = ref _businessComponentFilter.GetEntity(index);
                    ref var buyCommandComponent = ref e.Get<UpgradeBusinessComponent>();
                });

                businessPresenterComponent.Presenter.AddUpgradeModifierClickListener(indexButton =>
                {
                    ref var e = ref _businessComponentFilter.GetEntity(index);
                    ref var buyModifierComponent = ref e.Get<BuyModifierComponent>();
                    buyModifierComponent.IndexModifier = indexButton;
                });
            }
        }

        private BusinessLayout InstantiatePrefab()
        {
            return Object.Instantiate(_layoutConfig.Prefab, _layoutConfig.ContentLayout);
        }
    }
}