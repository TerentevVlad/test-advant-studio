using System;
using System.Collections.Generic;
using Configs.Balance;
using Configs.Resource;
using UnityEngine;

namespace DefaultNamespace.Configs
{
    [CreateAssetMenu(menuName = "Configs/BusinessConfig", fileName = nameof(BusinessConfig))]
    public class BusinessConfig : ScriptableObject
    {
        [SerializeField] private string _key;
        [SerializeField] private string _name = "title";
        [SerializeField] private float _productionTime = 10;

        [SerializeField] private AttributeConfig _baseIncome;

        [SerializeField] private List<AttributeConfig> _multipliersIncome;
        // [SerializeField] private ProgressionValue _multiplierIncome1;
        // [SerializeField] private ProgressionValue _multiplierIncome2;
        public string Name => _name;

        public float ProductionTime => _productionTime;
        public string Key => _key;


        public AttributeConfig GetIncomeAttribute() => _baseIncome;
        public double GetIncome(int levelBusiness) => _baseIncome.GetValue(levelBusiness);

        public AttributeConfig GetMultiplierIncome(int index)
        {
            return _multipliersIncome[index];
        }

        public int NumMultiplierAttributes => _multipliersIncome.Count;
    }

    

    [Serializable]
    public class AttributeConfig
    {
        [SerializeField] private string _name;
        [SerializeField] private CostValue _cost;
        [SerializeField] private ProgressionValue _value;

        public IResourceConfig ResourceConfig => _cost.Resource;
        public double GetCost(int level) => _cost.GetValue(level);
        public double GetValue(int level) => _value.GetValue(level);

        public string GetName() => _name;

    }

   
}