using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class InteractionBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        private Building _displayedBuilding;

        public override void DisplayBuilding(Building building)
        {
            Clear();
            _displayedBuilding = building;

            building.OnInteractionHidden += Clear;
            buildingDisplayer.DisplayBuilding(building);
            //Debug.Log($"Building {building} displayed");
        }

        public override void Clear()
        {
            if (_displayedBuilding == null) { return; }

            _displayedBuilding.OnInteractionHidden -= Clear;
            buildingDisplayer.Clear();

            _displayedBuilding = null;
            //Debug.Log("Display cleared");
        }
    }
}