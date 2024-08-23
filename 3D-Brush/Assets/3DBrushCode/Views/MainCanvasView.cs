using UnityEngine;
using UnityEngine.UI;

namespace _3DBrushCode.Views {
    public class MainCanvasView : MonoBehaviour {
        public ButtonsView buttonsView;
        public Slider brushSizeSlider;
        public LoadTexturesPopupView loadTexturesPopupView; 
        public SaveTexturePopupView saveTexturePopupView;

        //TODO: move it to popupController
        //it is bad practice to have logic in view in my opinion
        private void Awake() {
            buttonsView.openLoadPopupButton.onClick.AddListener(() => loadTexturesPopupView.gameObject.SetActive(true));
            buttonsView.openSavePopupButton.onClick.AddListener(() => saveTexturePopupView.gameObject.SetActive(true));
        }
    }

}
