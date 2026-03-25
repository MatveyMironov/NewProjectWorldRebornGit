using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.Implementations
{
    public class BuildingConstructionButtonMB : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ABuildingConfigurationDisplayerMB buildingConfigurationDisplayer;
        [SerializeField] private GameObject selectionIndicator;

        public event Action OnButtonClicked;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
            OnBuildingDeselected();
        }

        public void DisplayBuildingConfiguration(IBuildingConfiguration configuration)
        {
            buildingConfigurationDisplayer.DisplayBuildingConiguration(configuration);
        }

        public void OnBuildingSelected()
        {
            selectionIndicator.SetActive(true);
        }

        public void OnBuildingDeselected()
        {
            selectionIndicator.SetActive(false);
        }

        private void OnButtonClick()
        {
            OnButtonClicked?.Invoke();
        }
    }
}