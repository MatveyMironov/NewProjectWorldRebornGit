using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AManufactureBuildingRecorderMB : MonoBehaviour
    {
        protected abstract IBuildingManufacturesManager BuildingManufacturesManager { get; }

        protected virtual void OnEnable()
        {
            ManufactureBuildingConfigurationSO.OnManufactureBuildingCreated += RegisterManufactureBuilding;
        }

        protected virtual void OnDisable()
        {
            ManufactureBuildingConfigurationSO.OnManufactureBuildingCreated -= RegisterManufactureBuilding;
        }

        private void RegisterManufactureBuilding(Building building, IManufacture manufacture)
        {
            BuildingManufacturesManager.TryAddBuildingManufacture(building, manufacture);
        }
    }
}