using System.Collections.Generic;
using UnityEngine;

namespace _3DBrushCode.Logic.Contracts {
    public interface ITextureStorageService {
        public void SetObject(GameObject paintObject);
        public void SaveTexture(string fileName);
        public void LoadTexture(string fileName);
        public List<string> GetSavedTextures();
    }
}
