using EmployerManufactureSystem;
using EmployerSystem;
using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonEmployerManufactureBuildingRegisterMB : MonoBehaviour
    {
        private readonly IStructureBuildingsManager _structureBuildingsManager = StructureBuildingsManagerSingleton.Instance;

        private readonly IBuildingEmployersManager _buildingEmployersManager = BuildingEmployersManagerSingleton.Instance;
        private readonly IBuildingManufacturesManager _buildingManufacturesManager = BuildingManufacturesManagerSingleton.Instance;

        private void OnEnable()
        {
            EmployerManufactureBuildingConfigurationSO.OnBuildingCreated += RegisterBuilding;
            _structureBuildingsManager.OnBuildingRemoved += UnregisterBuilding;
        }

        private void OnDisable()
        {
            EmployerManufactureBuildingConfigurationSO.OnBuildingCreated -= RegisterBuilding;
            _structureBuildingsManager.OnBuildingRemoved -= UnregisterBuilding;
        }

        private void RegisterBuilding(Building building, IEmployer employer, IManufacture manufacture)
        {
            _buildingEmployersManager.TryAddBuildingEmployer(building, employer);
            _buildingManufacturesManager.TryAddBuildingManufacture(building, manufacture);
        }

        private void UnregisterBuilding(Building building)
        {
            _buildingEmployersManager.TryRemoveBuildingEmployer(building);
            _buildingManufacturesManager.TryRemoveBuildingManufacture(building);
        }
    }
}