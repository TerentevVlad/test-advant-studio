using UnityEngine;
using UnityEngine.UI;

namespace Layouts
{
    public class ProgressLayout : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetNormalizedValue(double value)
        {
            _slider.value = (float)value;
        }
    }
}