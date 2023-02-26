using System;
using Layouts;
using UnityEngine;

namespace Installers
{
    [Serializable]
    public class BusinessLayoutConfig
    {
        [SerializeField] private BusinessLayout _prefab;
        [SerializeField] private Transform _contentLayout;
        public BusinessLayout Prefab => _prefab;

        public Transform ContentLayout => _contentLayout;
    }
}