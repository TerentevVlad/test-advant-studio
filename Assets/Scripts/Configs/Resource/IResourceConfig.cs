using UnityEngine;

namespace Configs.Resource
{
    public interface IResourceConfig
    {
        public Sprite Sprite { get; }
        public string Key { get; }
    }
}