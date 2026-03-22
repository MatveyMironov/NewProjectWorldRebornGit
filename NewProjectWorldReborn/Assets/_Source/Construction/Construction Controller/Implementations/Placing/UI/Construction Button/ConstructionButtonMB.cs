using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ConstructionUISystem
{
    public class ConstructionButtonMB : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buildingNameText;

        public event Action OnButtonClicked;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void DisplayBuilding(string buildingName)
        {
            buildingNameText.text = buildingName;
        }

        private void OnButtonClick()
        {
            OnButtonClicked?.Invoke();
        }
    }
}