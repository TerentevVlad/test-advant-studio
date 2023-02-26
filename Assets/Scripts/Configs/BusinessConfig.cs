using System;
using UnityEngine;

namespace DefaultNamespace.Configs
{
    [CreateAssetMenu(menuName = "Configs/BusinessConfig", fileName = nameof(BusinessConfig))]
    public class BusinessConfig : ScriptableObject
    {
        [SerializeField] private string _name = "title";
        [SerializeField] private float _productionTime = 10;

        [SerializeField] private ProgressionValue _income;
        [SerializeField] private ProgressionValue _businessCost;
        
        [SerializeField] private ProgressionValue _multiplierIncome1;
        [SerializeField] private ProgressionValue _multiplierIncome2;
        public string Name => _name;

        public float ProductionTime => _productionTime;

        public double GetCost(int level) => _businessCost.GetValue(level);

        public double GetIncome(int levelBusiness) => _income.GetValue(levelBusiness);

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
        [SerializeField] private ProgressionValue _cost;
        [SerializeField] private ProgressionValue _value;
        
    }

   
}