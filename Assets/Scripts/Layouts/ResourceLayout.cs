using Configs.Resource;
using Configs.Resource.InternalAssets.Infrustructure.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Layouts
{
    public class ResourceLayout : MonoBehaviour
    {
        [SerializeField] private RectTransform _iconContainer;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;


        public void SetValue(IResourceConfig resourceConfig, double value)
        {
            SetValue(resourceConfig, value.ToBigNum());
        }
    
        public void SetValue(IResourceConfig resourceConfig, string value)
        {
            if(resourceConfig != null)
                _icon.sprite = resourceConfig.Sprite;
            _text.text = value;
        }
    

        public void SetValue(double value)
        {
            _text.text = value.ToBigNum();
        }

        public void SetActiveResourceIcon(bool isActive)
        {
            _iconContainer.gameObject.SetActive(isActive);
        }
    }
}
