using DefaultNamespace;
using Leopotam.Ecs;

namespace Systems
{
    public class BusinessPresenterSystem : IEcsRunSystem
    {
        private PlayerResourceContainer _playerResourceContainer;
        private EcsFilter<LevelComponent, BusinessPresenterComponent, BusinessComponent, LevelModifiersIncomeComponent> _filter;
        public void Run()
        {

            foreach (var index in _filter)
            {
                var level = _filter.Get1(index).Level;
                var presenter =  _filter.Get2(index).Presenter;
                var config = _filter.Get3(index).BusinessConfig;
                var modifierLevels = _filter.Get4(index).Levels;
                
                var incomeAttribute = config.GetIncomeAttribute();
                
                
                presenter.SetLevel(level);
                presenter.SetUpgradeCost(incomeAttribute, level);

                var resource = _playerResourceContainer.GetResource(incomeAttribute.ResourceConfig.Key);
                var cost = incomeAttribute.GetCost(level);
                presenter.SetInteractableUpgradeButton(resource.Value >= cost);

                
                for (int i = 0; i < modifierLevels.Count; i++)
                {
                    var modifierLevel = modifierLevels[i];
                    
                    var incomeAttributeModifier = config.GetMultiplierIncome(i);
                    resource = _playerResourceContainer.GetResource(incomeAttributeModifier.ResourceConfig.Key);
                    cost = incomeAttributeModifier.GetCost(modifierLevel);
                    
                    
                    bool isPurchased = modifierLevel >= 1;
                    bool isEnoughResource = resource.Value >= cost;
                    bool isInteractable = !isPurchased && isEnoughResource;
                
                    
                   
                    
                    presenter.SetInteractableModifierButton(i, isInteractable);
                    presenter.SetModifierValue(i, incomeAttributeModifier);
                   
                    if (isPurchased)
                    {
                        presenter.SetPurchasedStatusModifierButton(i, isPurchased);
                    }
                    else
                    {
                        presenter.SetModifierUpgradeCost(i, incomeAttributeModifier, modifierLevel);
                    }
                }

                
                    
            }
        }
    }
}