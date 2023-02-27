using Components;
using Components.Income;
using Components.StateComponents;
using Leopotam.Ecs;
using ResourceSystem;
using UnityEngine;

namespace Systems
{
    public class BusinessProductionProcessSystem : IEcsRunSystem
    {
        private EcsFilter<ProductionComponent, BusinessComponent, BusinessIncome> _productionFilter;
        private PlayerResourceContainer _playerResourceContainer;
        
        public void Run()
        {
            foreach (var index in _productionFilter)
            {
                ref var productionComponent = ref _productionFilter.Get1(index);
                if (productionComponent.IsActive)
                {
                    productionComponent.PassTime += Time.deltaTime;
                    if (productionComponent.PassTime >= productionComponent.ProductionTime)
                    {
                        ref var incomeComponent = ref _productionFilter.Get3(index);

                        _playerResourceContainer.AddSoft(incomeComponent.Income);
                        productionComponent.PassTime = 0;
                    }
                }
            }       
        }
    }
}