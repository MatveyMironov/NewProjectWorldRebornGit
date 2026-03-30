using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AManufactureBuildingRegisterMB : MonoBehaviour
    {
        protected abstract IStructureBuildingsManager BuildingsManager { get; }
        protected abstract IManufacturesManager ManufacturesManager { get; }

        protected virtual void OnEnable()
        {
            BuildingsManager.OnBuildingAdded += RegisterManufactureIfBuildingHasIt;
            BuildingsManager.OnBuildingRemoved += UnregisterManufactureIfBuildingHasIt;
        }

        protected virtual void OnDisable()
        {
            BuildingsManager.OnBuildingAdded -= RegisterManufactureIfBuildingHasIt;
            BuildingsManager.OnBuildingRemoved -= UnregisterManufactureIfBuildingHasIt;
        }

        private void RegisterManufactureIfBuildingHasIt(Building building)
        {
            IManufacture manufacture = building.Interior.Manufacture;

            if (manufacture != null)
            {
                ManufacturesManager.TryAddManufacture(manufacture);
            }
        }

        private void UnregisterManufactureIfBuildingHasIt(Building building)
        {
            IManufacture manufacture = building.Interior.Manufacture;

            if (manufacture != null)
            {
                ManufacturesManager.TryRemoveManufacture(manufacture);
            }
        }
    }
}