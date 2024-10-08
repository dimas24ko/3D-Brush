using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _3DBrushCode.Views {
    public class ButtonsView : MonoBehaviour {
        public Button rotateButton;
        public List<ButtonByColor> buttonsByColorMap;
        public Button openSavePopupButton;
        public Button openLoadPopupButton;
        public Button clearButton;
    }
}
