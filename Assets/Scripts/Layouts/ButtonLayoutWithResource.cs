using Configs.Resource;
using UnityEngine;

namespace Layouts
{
    public class ButtonLayoutWithResource : ButtonLayout
    {
        [SerializeField] private ResourceLayout _resourceLayout;

        public ResourceLayout ResourceLayout => _resourceLayout;
        public void SetResource(IResourceConfig resourceConfig, double value)
        {
            _resourceLayout.SetValue(resourceConfig, value);
        }

        public void SetResource(IResourceConfig resourceConfig, string value)
        {
            _resourceLayout.SetValue(resourceConfig, value);
        }
        public void SetActiveResourceIcon(bool isActive)
        {
            _resourceLayout.SetActiveResourceIcon(isActive);
        }
    }
}