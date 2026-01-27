using BuildingInfoSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingInfoDisplayerMB infoDisplayer;

        private Building _displayedBuilding;

        public override void DisplayBuilding(Building building)
        {
            Clear();

            //building.Structure.BuildingView.ShowSelection(true);
            infoDisplayer.DisplayBuildingInfo(building.Info);
            _displayedBuilding = building;
        }

        public override void Clear()
        {
            if (_displayedBuilding == null) return;

            //_selectedBuilding.Structure.View.ShowSelection(false);
            infoDisplayer.Clear();
            _displayedBuilding = null;
        }
    }
}