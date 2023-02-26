using System.Collections.Generic;
using Components;
using DefaultNamespace.Configs;
using Leopotam.Ecs;

namespace DefaultNamespace
{
    public class BusinessInitSystem : IEcsInitSystem
    {
        private List<BusinessConfig> _businessConfigs;
        private EcsWorld _world;

        public void Init()
        {
            foreach (var business in _businessConfigs)
            {
                var businessEntity = _world.NewEntity();

                ref var incomeComponent = ref businessEntity.Get<BusinessIncome>();
                ref var baseIncomeComponent = ref businessEntity.Get<BaseIncomeComponent>();
                ref var multiplierIncomeComponent = ref businessEntity.Get<MultiplierIncomeComponent>();
                
                ref var modifierComponent = ref businessEntity.Get<LevelModifiersIncomeComponent>();
                ref var levelComponent = ref businessEntity.Get<LevelComponent>();
                
                
                
                ref var productionComponent = ref businessEntity.Get<ProductionComponent>();
                productionComponent.ProductionTime = business.ProductionTime;
                productionComponent.PassTime = 0;
                productionComponent.IsActive = false;
                
                
                ref var businessComponent = ref businessEntity.Get<BusinessComponent>();

                businessComponent.Name = business.Name;
                businessComponent.ProductionTime = productionComponent;
                businessComponent.BusinessConfig = business;

            }
        }
    }
}
    