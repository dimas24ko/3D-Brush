using System;
using System.Collections.Generic;
using _3DBrushCode.Views;
using UnityEngine;

namespace _3DBrushCode.Logic.Services.ColorSelector {
    public class PaintColorSelector {
        private const float ScaleMultiplier = 1.2f;
        private const float ScaleDefault = 1f;
        private readonly List<ButtonByColor> _buttons;
        
        public Action<Color> OnColorSelected;
        
        public PaintColorSelector(List<ButtonByColor> buttons) {
            _buttons = buttons;
            BindEvents();
        }
        
        //TODO: Implement UnBind method when it will be needed
        private void BindEvents() {
            foreach (ButtonByColor button in _buttons) {
                button.button.onClick.AddListener(() => OnColorButtonClick(button));
            }
        }
        
        private void OnColorButtonClick(ButtonByColor clickedButton) {
            foreach (ButtonByColor button in _buttons) {
                button.button.transform.localScale = Vector3.one * ScaleDefault;
            }
            
            OnColorSelected?.Invoke(clickedButton.color);
            clickedButton.button.transform.localScale = Vector3.one * ScaleMultiplier;
        }
    }
}
