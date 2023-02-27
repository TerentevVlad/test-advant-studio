using System;
using Configs.Balance;
using Configs.Resource;
using UnityEngine;

namespace DefaultNamespace.Configs
{
    [CreateAssetMenu(menuName = "Configs/BusinessConfig", fileName = nameof(BusinessConfig))]
    public class BusinessConfig : ScriptableObject
    {
        [SerializeField] private string _name = "title";
        [SerializeField] private float _productionTime = 10;

        [SerializeField] private AttributeConfig _baseIncome;

        [SerializeField] private ProgressionValue _multiplierIncome1;
        [SerializeField] private ProgressionValue _multiplierIncome2;
        public string Name => _name;

        public float ProductionTime => _productionTime;


        public AttributeConfig GetIncomeAttribute() => _baseIncome;
        public double GetIncome(int levelBusiness) => _baseIncome.GetValue(levelBusiness);

        public double GetMultiplierIncome(int index, int level)
        {
            switch (index)
            {
                case 0: return _multiplierIncome1.GetValue(level);
                case 1 : return _multiplierIncome2.GetValue(level);
                default: throw new NotImplementedException();
            }
        }
        public double GetMultiplier1Income(int level)
        {
            return _multiplierIncome1.GetValue(level);
        }
        
        public double GetMultiplier2Income(int level)
        {
            return _multiplierIncome2.GetValue(level);
        }
    }


    [Serializable]
    public class AttributeConfig
    {
        [SerializeField] private CostValue _cost;
        [SerializeField] private ProgressionValue _value;

        public IResourceConfig ResourceConfig => _cost.Resource;
        public double GetCost(int level) => _cost.GetValue(level);
        public double GetValue(int level) => _value.GetValue(level);

    }

   
}