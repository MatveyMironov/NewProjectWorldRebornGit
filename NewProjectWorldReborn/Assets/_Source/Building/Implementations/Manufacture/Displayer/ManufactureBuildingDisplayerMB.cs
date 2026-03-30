using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations.Manufacture
{
    public class ManufactureBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private AManufactureDisplayerMB manufactureDisplayer;

        public override void DisplayBuilding(Building building)
        {
            IManufacture buildingManufacture = building.Interior.Manufacture;

            if (buildingManufacture != null)
            {
                manufactureDisplayer.DisplayManufacture(buildingManufacture);
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