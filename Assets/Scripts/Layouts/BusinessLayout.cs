using System;
using System.Collections.Generic;
using Components;
using Configs.Resource;
using TMPro;
using UnityEngine;

namespace Layouts
{
    public class BusinessLayout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private PropertyLayout _propertyLevel;
        [SerializeField] private PropertyLayout _propertyIncome;
        [SerializeField] private ButtonLayoutWithResource _buttonUpgrade;
        [SerializeField] private ProgressLayout _progressLayout;
        [SerializeField] private List<ButtonLayoutPropertyWithResource> _buttonsModifier;

        

        public void Init(BusinessComponent businessComponent)
        {
            _title.text = businessComponent.Name;
        }

        public void AddBuyClickListener(Action onClick)
        {
            _buttonUpgrade.AddOnClickListener(onClick);
        }

        public void SetProgress(float current, float max)
        {
            _progressLayout.SetNormalizedValue(current / max);
        }

        public void SetLevel(int level)
        {
            _propertyLevel.SetValue(level.ToString());
        }

        public void SetIncome(string toBigNum)
        {
            _propertyIncome.SetValue(toBigNum);
        }

        public void SetUpgradeCost(IResourceConfig resourceConfig, double cost)
        {
            _buttonUpgrade.SetResource(resourceConfig, cost);
        }

        public void SetModifierUpgradeCost(int index, IResourceConfig resourceConfig, double cost)
        {
            _buttonsModifier[index].SetResource(resourceConfig, cost);
        }
        public void SetInteractableUpgradeButton(bool isInteractable)
        {
            _buttonUpgrade.SetInteractable(isInteractable);
        }

        public void AddUpgradeModifierClickListener(Action<int> onClick)
        {
            for (int i = 0; i < _buttonsModifier.Count; i++)
            {
                var button = _buttonsModifier[i];
                var index = i;
                button.AddOnClickListener(() =>
                {
                    onClick?.Invoke(index);
                });
            }
        }

        public void SetInteractableModifierButton(int index, bool isInteractable)
        {
            _buttonsModifier[index].SetInteractable(isInteractable);
        }

        public void SetPurchasedStatusModifierButton(int index, bool isPurchased)
        {
            _buttonsModifier[index].SetActiveResourceIcon(!isPurchased);
            _buttonsModifier[index].SetResource(null, "Purchased");
        }


        public void SetModifierValue(int index, string percent)
        {
            _buttonsModifier[index].SetPropertyValue(percent);
        }

        public void SetModifierName(int index, string title)
        {
            _buttonsModifier[index].SetTitle(title);
        }
    }
}