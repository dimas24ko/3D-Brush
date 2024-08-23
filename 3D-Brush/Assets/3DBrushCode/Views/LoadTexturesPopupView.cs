using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _3DBrushCode.Views {
    public class LoadTexturesPopupView : MonoBehaviour {
        public Transform parentForRow;
        public RowView rowPrefab;
        public Button closeButton;
        
        public List<RowView> rows = new List<RowView>();

        public Action<RowView> OnAddRow;

        //TODO: move it to popupController
        //it is bad practice to have logic in view in my opinion
        private void Awake() {
            closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }
        
        public void AddRow(string textureName) {
            RowView row = Instantiate(rowPrefab, parentForRow);
            row.nameText.text = textureName;
            rows.Add(row);
            OnAddRow?.Invoke(row);
        }
    }
}
