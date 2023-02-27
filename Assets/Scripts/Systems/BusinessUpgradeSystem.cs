using System.Collections.Generic;
using Components;
using Components.EventComponents;
using Components.StateComponents;
using Configs;
using Leopotam.Ecs;
using ResourceSystem;
using Saves;

namespace Systems
{
    public class BusinessUpgradeSystem : IEcsRunSystem
    {
        private EcsFilter<LevelComponent, UpgradeBusinessComponent, BusinessComponent> _upgradeComponentFilter;
        private EcsFilter<LevelModifiersIncomeComponent, BuyModifierComponent, BusinessComponent> _modifierComponentFilter;
        
        private Dictionary<BusinessConfig, BusinessDbAdapter> _businessDbAdapters;

        private PlayerResourceContainer _playerResourceContainer;

       
        public void Run()
        {
            foreach (var index in _upgradeComponentFilter)
            {
                ref var entity = ref _upgradeComponentFilter.GetEntity(index);
                
                ref var levelComponent = ref _upgradeComponentFilter.Get1(index);
                ref var command = ref _upgradeComponentFilter.Get2(index);
                var config = _upgradeComponentFilter.Get3(index).BusinessConfig;
                var incomeAttribute = _upgradeComponentFilter.Get3(index).BusinessConfig.GetIncomeAttribute();
                
                var resource = _playerResourceContainer.GetResource(incomeAttribute.ResourceConfig.Key);
                var cost = incomeAttribute.GetCost(levelComponent.Level);

                if (resource.Value >= cost)
                {
                    _playerResourceContainer.Subtract(resource.ResourceConfig, cost);
                    levelComponent.Level++;
                    
                    SaveLevel(config, levelComponent.Level);
                }

                entity.Del<UpgradeBusinessComponent>();
            }

            foreach (var index in _modifierComponentFilter)
            {
                ref var entity = ref _modifierComponentFilter.GetEntity(index);
                ref var levelComponent = ref _modifierComponentFilter.Get1(index);
                var buyModifierComponent = _modifierComponentFilter.Get2(index);
                var indexModifier = buyModifierComponent.IndexModifier;
                var config = _upgradeComponentFilter.Get3(index).BusinessConfig;
                
                var multiplierAttribute = _modifierComponentFilter.Get3(index).BusinessConfig.GetMultiplierIncome(indexModifier);

                
                
                var resource = _playerResourceContainer.GetResource(multiplierAttribute.ResourceConfig.Key);
                var cost = multiplierAttribute.GetCost(levelComponent.Levels[indexModifier]);

                if (resource.Value >= cost)
                {
                    _playerResourceContainer.Subtract(resource.ResourceConfig, cost);
                    levelComponent.Levels[indexModifier]++;
                    SaveLevelModifiers(config, levelComponent.Levels);
                }
                
               
                entity.Del<BuyModifierComponent>();
            }
        }
        
        private void SaveLevel(BusinessConfig config, int level)
        {
            var dbAdapter = _businessDbAdapters[config];
            var businessData = dbAdapter.Get();
            businessData.Level = level;
            dbAdapter.Set(businessData);
        }

        private void SaveLevelModifiers(BusinessConfig config, List<int> levels)
        {
            var dbAdapter = _businessDbAdapters[config];
            var businessData = dbAdapter.Get();
            businessData.LevelModifiers = levels;
            dbAdapter.Set(businessData);
        }
    }
}