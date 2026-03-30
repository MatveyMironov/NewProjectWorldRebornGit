using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations.Manufacture
{
    public class BuildingManufactureDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AManufactureDisplayerMB manufactureDisplayer;

        public override void DisplayBuilding(Building building)
        {
            IManufacture buildingManufacture = building.Interior.Manufacture;

            if (buildingManufacture == null)
            {
                Clear();
                return;
            }

            manufactureDisplayer.DisplayManufacture(buildingManufacture);
        }

        public override void Clear()
        {
            manufactureDisplayer.Clear();
        }
    }
}