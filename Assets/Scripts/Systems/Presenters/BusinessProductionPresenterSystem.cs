using Components;
using Components.StateComponents;
using Leopotam.Ecs;

namespace Systems.Presenters
{
    public class BusinessProductionPresenterSystem : IEcsRunSystem
    {
        private EcsFilter<ProductionComponent, BusinessPresenterComponent> _productionFilter;
        
        public void Run()
        {
            foreach (var index in _productionFilter)
            {
                ref var businessComponent = ref _productionFilter.Get1(index);
                var presenterComponent = _productionFilter.Get2(index);
                if (businessComponent.IsActive)
                {
                    presenterComponent.Presenter.SetProgress(businessComponent);
                }
            }       
        }
    }
}