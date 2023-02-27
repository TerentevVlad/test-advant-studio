using Installers;
using Layouts;
using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class BusinessUpgradeSystem : IEcsRunSystem
    {
        private EcsFilter<LevelComponent, UpgradeBusinessComponent, BusinessComponent> _upgradeComponentFilter;
        private EcsFilter<LevelModifiersIncomeComponent, BuyModifierComponent, BusinessComponent> _modifierComponentFilter;
        
        private PlayerResourceContainer _playerResourceContainer;
        public void Run()
        {
            foreach (var index in _upgradeComponentFilter)
            {
                ref var entity = ref _upgradeComponentFilter.GetEntity(index);
                
                ref var levelComponent = ref _upgradeComponentFilter.Get1(index);
                ref var command = ref _upgradeComponentFilter.Get2(index);
                
                var incomeAttribute = _upgradeComponentFilter.Get3(index).BusinessConfig.GetIncomeAttribute();
                
                var resource = _playerResourceContainer.GetResource(incomeAttribute.ResourceConfig.Key);
                var cost = incomeAttribute.GetCost(levelComponent.Level);

                if (resource.Value >= cost)
                {
                    _playerResourceContainer.Subtract(resource.ResourceConfig, cost);
                    levelComponent.Level++;
                }

                entity.Del<UpgradeBusinessComponent>();
            }

            foreach (var index in _modifierComponentFilter)
            {
                ref var entity = ref _modifierComponentFilter.GetEntity(index);
                ref var levelComponent = ref _modifierComponentFilter.Get1(index);
                var buyModifierComponent = _modifierComponentFilter.Get2(index);
                var indexModifier = buyModifierComponent.IndexModifier;
                
                var multiplierAttribute = _modifierComponentFilter.Get3(index).BusinessConfig.GetMultiplierIncome(indexModifier);

                
                
                var resource = _playerResourceContainer.GetResource(multiplierAttribute.ResourceConfig.Key);
                var cost = multiplierAttribute.GetCost(levelComponent.Levels[indexModifier]);

                if (resource.Value >= cost)
                {
                    Debug.LogError("Subtract "+  cost);
                    _playerResourceContainer.Subtract(resource.ResourceConfig, cost);
                    levelComponent.Levels[indexModifier]++;
                }
                
               
                entity.Del<BuyModifierComponent>();
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

                var businessConfig = businessComponent.BusinessConfig;
                
                ref var businessPresenterComponent = ref entity.Get<BusinessPresenterComponent>();
                
                businessPresenterComponent.Presenter = new BusinessLayoutPresenter(layout);
                businessPresenterComponent.Presenter.Init(businessComponent);
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