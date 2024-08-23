using UnityEngine;

namespace _3DBrushCode.Logic.Contracts {
    public interface IUnityObjectFactory {
        public GameObject CreateObject(PrimitiveType type);
    }
}
