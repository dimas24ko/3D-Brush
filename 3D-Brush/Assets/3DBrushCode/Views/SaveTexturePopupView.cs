using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _3DBrushCode.Views {
    public class SaveTexturePopupView : MonoBehaviour {
        public Button closeButton;
        public Button saveButton;
        public TMP_InputField inputField;
        
        //TODO: move it to popupController
        //it is bad practice to have logic in view in my opinion
        private void Awake() {
            closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
    }
}
