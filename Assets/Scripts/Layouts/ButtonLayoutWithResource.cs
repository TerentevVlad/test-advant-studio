using Configs.Resource;
using UnityEngine;

namespace Layouts
{
    public class ButtonLayoutWithResource : ButtonLayout
    {
        [SerializeField] private ResourceLayout _resourceLayout;

        public void SetResource(IResourceConfig resourceConfig, double value)
        {
            _resourceLayout.Init(resourceConfig, value);
        }
    }
}