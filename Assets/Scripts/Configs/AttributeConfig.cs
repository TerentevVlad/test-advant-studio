using System;
using Configs.Balance;
using Configs.Resource;
using UnityEngine;

namespace Configs
{
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