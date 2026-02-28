using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AManufactureBuildingRegisterMB : MonoBehaviour
    {
        protected abstract IBuildingManufacturesManager BuildingManufacturesManager { get; }
        protected abstract IStructureBuildingsManager StructureBuildingsManager { get; }

        protected virtual void OnEnable()
        {
            ManufactureBuildingConfigurationSO.OnManufactureBuildingCreated += RegisterManufactureBuilding;
            StructureBuildingsManager.OnBuildingRemoved += UnregisterManufactureBuilding;
        }

        protected virtual void OnDisable()
        {
            ManufactureBuildingConfigurationSO.OnManufactureBuildingCreated -= RegisterManufactureBuilding;
            StructureBuildingsManager.OnBuildingRemoved -= UnregisterManufactureBuilding;
        }

        private void RegisterManufactureBuilding(Building building, IManufacture manufacture)
        {
            BuildingManufacturesManager.TryAddBuildingManufacture(building, manufacture);
        }

        private void UnregisterManufactureBuilding(Building building)
        {
            BuildingManufacturesManager.TryRemoveBuildingManufacture(building);
        }
    }
}