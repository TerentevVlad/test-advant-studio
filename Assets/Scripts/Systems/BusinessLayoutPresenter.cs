using System;
using Configs.Resource.InternalAssets.Infrustructure.Extensions;
using DefaultNamespace.Configs;
using Layouts;
using UnityEngine;

namespace DefaultNamespace
{
    public class BusinessLayoutPresenter
    {
        private readonly BusinessLayout _layout;
        public BusinessLayoutPresenter(BusinessLayout layout)
        {
            _layout = layout;
        }
        
        public void Init(BusinessComponent businessComponent)
        {
            _layout.Init(businessComponent);
            SetProgress(businessComponent.ProductionTime);
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
    }
    
}