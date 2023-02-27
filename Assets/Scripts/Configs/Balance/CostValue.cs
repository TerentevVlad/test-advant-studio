using System;
using Configs.Resource;
using UnityEngine;

namespace Configs.Balance
{
    [Serializable]
    public class CostValue : ProgressionValue
    {
        [SerializeField] private ResourceConfig _resource;

        public ResourceConfig Resource => _resource;
    }
}