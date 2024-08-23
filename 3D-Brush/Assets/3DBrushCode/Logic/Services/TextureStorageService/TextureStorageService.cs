using System.Collections.Generic;
using System.IO;
using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Views;
using UnityEngine;

namespace _3DBrushCode.Logic.Services.TextureStorageService {
    //TODO: this is god class, refactor it
    //we can split it into 2 services: TextureSaveService and TextureLoadService
    //or we can split it into 2 services: TextureStorageService and TextureApplyingService
    public class TextureStorageService : ITextureStorageService {
        private const int TextureSize = 512;

        private readonly UnityReferenceView _unityReferenceView;
        private GameObject _gameObject;

        public TextureStorageService(UnityReferenceView unityReferenceView) {
            _unityReferenceView = unityReferenceView;

            BindEvents();
            
            List<string> allTextures = GetSavedTextures();
            foreach (string texture in allTextures) {
                _unityReferenceView.mainCanvasView.loadTexturesPopupView.AddRow(texture);
            }
        }

        public void SetObject(GameObject gameObject) {
            _gameObject = gameObject;
        }

        public void SaveTexture(string fileName) {
            var textureToSave = _gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;

            if (!fileName.EndsWith(".png")) {
                fileName += ".png";
            }

            byte[] bytes = textureToSave.EncodeToPNG();
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            File.WriteAllBytes(filePath, bytes);
        }

        public void LoadTexture(string fileName) {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);

            if (!File.Exists(filePath)) {
                return;
            }

            byte[] fileData = File.ReadAllBytes(filePath);

            Texture2D loadedTexture = new Texture2D(TextureSize, TextureSize);
            loadedTexture.LoadImage(fileData);

            _gameObject.GetComponent<MeshRenderer>().material.mainTexture = loadedTexture;
        }

        public List<string> GetSavedTextures() {
            string directoryPath = Application.persistentDataPath;
            string[] files = Directory.GetFiles(directoryPath, "*.png");

            List<string> textureFiles = new List<string>();

            foreach (string file in files) {
                textureFiles.Add(Path.GetFileName(file));
            }

            return textureFiles;
        }

        private void BindEvents() {
            _unityReferenceView.mainCanvasView.buttonsView.openSavePopupButton.onClick.AddListener(
                () => _unityReferenceView.mainCanvasView.saveTexturePopupView.gameObject.SetActive(true));

            _unityReferenceView.mainCanvasView.buttonsView.openLoadPopupButton.onClick.AddListener(
                () => _unityReferenceView.mainCanvasView.loadTexturesPopupView.gameObject.SetActive(true));

            _unityReferenceView.mainCanvasView.saveTexturePopupView.saveButton.onClick.AddListener(
                () => SaveTexture(_unityReferenceView.mainCanvasView.saveTexturePopupView.inputField.text));

            _unityReferenceView.mainCanvasView.loadTexturesPopupView.OnAddRow += (row) => {
                row.loadButton.onClick.AddListener(() => LoadTexture(row.nameText.text));
            };
        }
    }
}
