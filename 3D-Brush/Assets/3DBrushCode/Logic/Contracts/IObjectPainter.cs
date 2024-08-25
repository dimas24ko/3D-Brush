using UnityEngine;

namespace _3DBrushCode.Logic.Contracts {
    public interface IObjectPainter {
        public void SetObject(GameObject shape);
        public void Paint(Vector2 startUV, Vector2 endUV);
        public void UpdateBrushSize(int brushSize);
        public void UpdateColor(Color color);
        public void ClearTexture();
    }
}
