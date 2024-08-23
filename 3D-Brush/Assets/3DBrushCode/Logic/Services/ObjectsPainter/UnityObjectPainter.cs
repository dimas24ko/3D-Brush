using System.Collections.Generic;
using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Logic.Services.ColorSelector;
using _3DBrushCode.Views;
using UnityEngine;
using UnityEngine.UI;

namespace _3DBrushCode.Logic.Services.ObjectsPainter {
    public class UnityObjectPainter : IObjectPainter {
        private const int MinBrushSize = 1;
        private const int MaxBrushSize = 20;
        
        private readonly Slider _brushSizeSlider;
        private readonly PaintColorSelector _colorSelector;
            
        private GameObject _currentObject;
        private int _brushSize;
        private Color _color;

        public UnityObjectPainter(List<ButtonByColor> buttons, Slider brushSizeSlider) {
            _brushSizeSlider = brushSizeSlider;
            _colorSelector = new PaintColorSelector(buttons);
            BindEvents();
            SetDefaultValues();
        }

        public void SetObject(GameObject shape) {
            _currentObject = shape;
        }
        
        public void UpdateBrushSize(int brushSize) {
            _brushSize = brushSize;
        }
        
        public void UpdateColor(Color color) {
            _color = color;
        }

        public void Paint(Vector2 startUV, Vector2 endUV) {
            var texture = _currentObject.GetComponent<Renderer>().material.mainTexture as Texture2D;

            if (texture == null) {
                Debug.LogError("Texture is not found in the object: " + _currentObject.name);
                return;
            }

            int steps = Mathf.CeilToInt(Vector2.Distance(startUV, endUV) * texture.width);
            for (int i = 0; i <= steps; i++) {
                Vector2 lerpUV = Vector2.Lerp(startUV, endUV, i / (float)steps);
                int x = (int)(lerpUV.x * texture.width);
                int y = (int)(lerpUV.y * texture.height);

                for (int j = -_brushSize; j < _brushSize; j++) {
                    for (int k = -_brushSize; k < _brushSize; k++) {
                        if (x + j >= 0 && x + j < texture.width && y + k >= 0 && y + k < texture.height) {
                            texture.SetPixel(x + j, y + k, _color);
                        }
                    }
                }
            }

            texture.Apply();
        }
        
        //TODO: Implement UnBind method when it will be needed
        private void BindEvents() {
            _colorSelector.OnColorSelected += UpdateColor;
            _brushSizeSlider.onValueChanged.AddListener(UpdateBrushSize);
        }
        
        private void UpdateBrushSize(float percentage) {
            _brushSize = (int)Mathf.Lerp(MinBrushSize, MaxBrushSize, percentage);
        }
        
        private void SetDefaultValues() {
            //TODO: setting default values for my opinion
            _brushSize = (MaxBrushSize - MinBrushSize) / 2;
            _brushSizeSlider.value = 0.5f;
        }
    }
}
