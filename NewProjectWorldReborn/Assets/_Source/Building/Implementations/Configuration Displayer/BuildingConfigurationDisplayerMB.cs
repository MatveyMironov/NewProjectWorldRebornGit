using BuildingInfoSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingConfigurationDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private ABuildingInfoDisplayerMB buildingInfoDisplayer;

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            buildingInfoDisplayer.DisplayBuildingInfo(configuration.Info);
        }

        public override void Clear()
        {
            buildingInfoDisplayer.Clear();
        }
    }
}