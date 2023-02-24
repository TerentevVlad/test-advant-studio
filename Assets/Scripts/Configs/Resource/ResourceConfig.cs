using UnityEngine;

namespace Configs.Resource
{
    [CreateAssetMenu(menuName = "Configs/ResourceConfig", fileName = "ResourceConfig")]
    public class ResourceConfig : ScriptableObject, IResourceConfig
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _key;
        public Sprite Sprite => _icon;
        public string Key => _key;
    }
}