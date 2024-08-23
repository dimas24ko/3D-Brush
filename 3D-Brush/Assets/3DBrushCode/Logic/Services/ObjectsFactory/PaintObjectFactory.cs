using _3DBrushCode.Logic.Contracts;
using UnityEngine;

namespace _3DBrushCode.Logic.Services.ObjectsFactory {
    public class PaintObjectFactory : IUnityObjectFactory {
        private const int TextureSize = 512;
        
        private readonly Color _defaultColor = Color.white;

        public GameObject CreateObject(PrimitiveType type) {
            var shape = GameObject.CreatePrimitive(type);
            shape.transform.position = Vector3.zero;

            Object.Destroy(shape.GetComponent<SphereCollider>());
            shape.AddComponent<MeshCollider>();

            var renderComponent = shape.GetComponent<Renderer>();
            var texture = new Texture2D(TextureSize, TextureSize);
            renderComponent.material.mainTexture = texture;
            
            Color[] fillPixels = new Color[texture.width * texture.height];
            for (int i = 0; i < fillPixels.Length; i++) {
                fillPixels[i] = _defaultColor;
            }

            texture.SetPixels(fillPixels);
            texture.Apply();

            return shape;
        }
    }
}
