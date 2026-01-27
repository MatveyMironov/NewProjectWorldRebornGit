using BuildingSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingConstructionUISystem
{
    public class BuildingConstructionButtonMB : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ABuildingConfigurationDisplayerMB buildingConfigurationDisplayer;

        public event Action OnButtonClicked;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void DisplayBuildingConfiguration(IBuildingConfiguration configuration)
        {
            buildingConfigurationDisplayer.DisplayBuildingConiguration(configuration);
        }

        private void OnButtonClick()
        {
            OnButtonClicked?.Invoke();
        }
    }
}