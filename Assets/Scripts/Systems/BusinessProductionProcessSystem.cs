using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class BusinessProductionProcessSystem : IEcsRunSystem
    {
        private EcsFilter<ProductionComponent> _productionFilter;
        
        public void Run()
        {
            foreach (var index in _productionFilter)
            {
                ref var businessComponent = ref _productionFilter.Get1(index);
                if (businessComponent.IsActive)
                {
                    businessComponent.PassTime += Time.deltaTime;
                    if (businessComponent.PassTime >= businessComponent.ProductionTime)
                    {
                        businessComponent.PassTime = 0;
                    }
                }
            }       
        }
    }
}