using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Layouts
{
    public class ButtonLayout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTitle;
        [SerializeField] private Button _button;

        public void AddOnClickListener(Action onClick)
        {
            _button.onClick.AddListener(onClick.Invoke);
        }

        public void SetInteractable(bool isInteractable)
        {
            _button.interactable = isInteractable;
        }

        public void SetTitle(string title)
        {
            _textTitle.text = title;
        }
    }
}