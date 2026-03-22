using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class ManufactureBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AManufactureDisplayerMB manufactureDisplayer;

        private readonly IBuildingManufacturesManager _buildingManufacturesManager = BuildingManufacturesManagerSingleton.Instance;

        public override void DisplayBuilding(Building building)
        {
            if (_buildingManufacturesManager.TryGetBuildingManufacture(building, out IManufacture manufacture))
            {
                manufactureDisplayer.DisplayManufacture(manufacture);
            }
            else
            {
                Clear();
            }
        }

        public override void Clear()
        {
            manufactureDisplayer.Clear();
        }
    }
}