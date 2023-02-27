using Components;
using Components.Income;
using Leopotam.Ecs;

namespace Systems.Presenters
{
    public class BusinessIncomePresenterSystem : IEcsRunSystem
    {
        private EcsFilter<BusinessIncome, BusinessPresenterComponent> _productionFilter;
        
        public void Run()
        {
            foreach (var index in _productionFilter)
            {
                ref var incomeComponent = ref _productionFilter.Get1(index);
                var presenterComponent = _productionFilter.Get2(index);
                presenterComponent.Presenter.SetIncome(incomeComponent.Income);
            }       
        }
    }
}