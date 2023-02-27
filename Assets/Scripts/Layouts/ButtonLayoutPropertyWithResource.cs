using UnityEngine;

namespace Layouts
{
    public class ButtonLayoutPropertyWithResource : ButtonLayoutWithResource
    {
        [SerializeField] private PropertyLayout _propertyLayout;

        public void SetProperty(string title, string value)
        {
            _propertyLayout.SetTitle(title);
            _propertyLayout.SetValue(value);
        }
    }
}