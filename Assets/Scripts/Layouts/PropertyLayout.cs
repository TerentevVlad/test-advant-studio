using TMPro;
using UnityEngine;

namespace Layouts
{
    public class PropertyLayout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTitle;
        [SerializeField] private TextMeshProUGUI _textValue;

        public void SetTitle(string value)
        {
            _textTitle.text = value;
        }

        public void SetValue(string value)
        {
            _textValue.text = value;
        }
    }
}