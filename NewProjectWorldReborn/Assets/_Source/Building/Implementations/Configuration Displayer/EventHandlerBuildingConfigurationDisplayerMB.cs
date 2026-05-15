using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingSystem.Implementations
{
    public class EventHandlerBuildingConfigurationDisplayerMB : ABuildingConfigurationDisplayerMB, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField] private ABuildingConfigurationDisplayerMB buildingConfigurationDisplayer;

        private IBuildingConfiguration _displayedConfiguration;

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            _displayedConfiguration = configuration;
        }

        public override void Clear()
        {
            _displayedConfiguration = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_displayedConfiguration == null) { return; }

            buildingConfigurationDisplayer.DisplayBuildingConiguration(_displayedConfiguration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buildingConfigurationDisplayer.Clear();
        }
    }
}