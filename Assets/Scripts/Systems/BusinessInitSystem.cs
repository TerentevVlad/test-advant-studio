using System.Collections.Generic;
using Components;
using Components.Income;
using Components.StateComponents;
using Configs;
using Leopotam.Ecs;
using Saves;

namespace Systems
{
    public class BusinessInitSystem : IEcsInitSystem
    {
        private List<BusinessConfig> _businessConfigs;
        private Dictionary<BusinessConfig, BusinessDbAdapter> _businessDbAdapters;
        private EcsWorld _world;

        public void Init()
        {
            foreach (var business in _businessConfigs)
            {
                var dbAdapter = _businessDbAdapters[business];
                var businessEntity = _world.NewEntity();

                ref var incomeComponent = ref businessEntity.Get<BusinessIncome>();
                ref var baseIncomeComponent = ref businessEntity.Get<BaseIncomeComponent>();
                ref var multiplierIncomeComponent = ref businessEntity.Get<MultiplierIncomeComponent>();

                var data = dbAdapter.Get();
                ref var modifierComponent = ref businessEntity.Get<LevelModifiersIncomeComponent>();
                
                if (data.LevelModifiers.Count == 0)
                {
                    modifierComponent.Levels = new List<int>();
                    for (int i = 0; i < business.NumMultiplierAttributes; i++)
                    {
                        modifierComponent.Levels.Add(0);
                    }
                }
                else
                {
                    modifierComponent.Levels = data.LevelModifiers;
                }
                
                
                ref var levelComponent = ref businessEntity.Get<LevelComponent>();
                levelComponent.Level = dbAdapter.Get().Level;
                
                ref var productionComponent = ref businessEntity.Get<ProductionComponent>();
                productionComponent.ProductionTime = business.ProductionTime;
                productionComponent.PassTime = 0;
                productionComponent.IsActive = false;
                
                ref var businessComponent = ref businessEntity.Get<BusinessComponent>();

                businessComponent.Name = business.Name;
                businessComponent.BusinessConfig = business;
            }
        }
    }
}
    