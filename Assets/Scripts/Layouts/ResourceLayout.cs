using Configs.Resource;
using Configs.Resource.InternalAssets.Infrustructure.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLayout : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;


    public void Init(IResourceConfig resourceConfig, double value)
    {
        _icon.sprite = resourceConfig.Sprite;
        _text.text = value.ToBigNum();
    }

    public void SetValue(double value)
    {
        _text.text = value.ToBigNum();
    }
}
