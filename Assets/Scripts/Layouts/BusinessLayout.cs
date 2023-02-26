using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace Layouts
{
    public class BusinessLayout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private PropertyLayout _propertyLevel;
        [SerializeField] private PropertyLayout _propertyIncome;
        [SerializeField] private ButtonLayout _button;
        [SerializeField] private ProgressLayout _progressLayout;
        private void SetTitle(string title)
        {
            _title.text = title;
        }

        public void Init(BusinessComponent businessComponent)
        {
            SetTitle(businessComponent.Name);
        }

        public void AddBuyClickListener(Action onClick)
        {
            _button.AddOnClickListener(onClick);
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
    }
}