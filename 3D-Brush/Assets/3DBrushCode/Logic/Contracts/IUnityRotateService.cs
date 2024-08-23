using UnityEngine;

namespace _3DBrushCode.Logic.Contracts {
    public interface IUnityRotateService {
        public void SetObject(GameObject paintObject);
        public void Rotate();
    }
}

