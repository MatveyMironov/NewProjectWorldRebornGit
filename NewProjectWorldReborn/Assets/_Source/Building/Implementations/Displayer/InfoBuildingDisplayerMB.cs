using BuildingInfoSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class InfoBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingInfoDisplayerMB infoDisplayer;

        public override void DisplayBuilding(Building building)
        {
            infoDisplayer.DisplayBuildingInfo(building.Info);
        }

        public override void Clear()
        {
            infoDisplayer.Clear();
        }
    }
}