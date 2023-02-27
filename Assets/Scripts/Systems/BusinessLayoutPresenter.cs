using System;
using Configs.Resource.InternalAssets.Infrustructure.Extensions;
using DefaultNamespace.Configs;
using Layouts;

namespace DefaultNamespace
{
    public class BusinessLayoutPresenter
    {
        private readonly BusinessLayout _layout;
        public BusinessLayoutPresenter(BusinessLayout layout)
        {
            _layout = layout;
        }
        
        public void Init(BusinessComponent businessComponent, ProductionComponent productionComponent)
        {
            _layout.Init(businessComponent);
            SetProgress(productionComponent);
        }

        public void SetProgress(ProductionComponent productionComponent)
        {
            _layout.SetProgress(productionComponent.PassTime, productionComponent.ProductionTime);
        }

        public void AddBuyClickListener(Action onClick)
        {
            _layout.AddBuyClickListener(onClick);
        }
        
        public void SetLevel(int level)
        {
            _layout.SetLevel(level);
        }

        public void SetIncome(double income)
        {
            _layout.SetIncome(income.ToBigNum());
        }

        public void SetUpgradeCost(AttributeConfig attributeConfig, int level)
        {
            var cost = attributeConfig.GetCost(level);
            var resourceConfig = attributeConfig.ResourceConfig;
            _layout.SetUpgradeCost(resourceConfig, cost);
        }

        public void SetInteractableUpgradeButton(bool isInteractable)
        {
            _layout.SetInteractableUpgradeButton(isInteractable);
        }

        public void AddUpgradeModifierClickListener(Action<int> onClick)
        {
            _layout.AddUpgradeModifierClickListener(onClick);
        }

        public void SetInteractableModifierButton(int index, bool isInteractable)
        {
            _layout.SetInteractableModifierButton(index, isInteractable);
        }

        public void SetPurchasedStatusModifierButton(int index, bool isPurchased)
        {
            _layout.SetPurchasedStatusModifierButton(index, isPurchased);
        }

        public void SetModifierUpgradeCost(int index, AttributeConfig incomeAttribute, int level)
        {
            var cost = incomeAttribute.GetCost(level);
            var resourceConfig = incomeAttribute.ResourceConfig;
            _layout.SetModifierUpgradeCost(index, resourceConfig, cost);
            
        }

        public void SetModifierValue(int index, AttributeConfig incomeAttributeModifier)
        {
            var value = incomeAttributeModifier.GetValue(1);
            value *= 100;
            value -= 100;
            string percent = $"+{value}%";
            _layout.SetModifierValue(index, percent);
            _layout.SetModifierName(index, incomeAttributeModifier.GetName());
        }
    }
    
}