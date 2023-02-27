using DefaultNamespace;
using Leopotam.Ecs;

namespace Systems
{
    public class BusinessPresenterSystem : IEcsRunSystem
    {
        private PlayerResourceContainer _playerResourceContainer;
        private EcsFilter<LevelComponent, BusinessPresenterComponent, BusinessComponent> _filter;
        public void Run()
        {

            foreach (var index in _filter)
            {
                var level = _filter.Get1(index).Level;
                var presenter =  _filter.Get2(index).Presenter;
                var config = _filter.Get3(index).BusinessConfig;
                
                var incomeAttribute = config.GetIncomeAttribute();
                
                
                presenter.SetLevel(level);
                presenter.SetUpgradeCost(incomeAttribute, level);

                var resource = _playerResourceContainer.GetResource(incomeAttribute.ResourceConfig.Key);
                var cost = incomeAttribute.GetCost(level);
                
                presenter.SetInteractableUpgradeButton(resource.Value >= cost);
                
                    
            }
        }
    }
}